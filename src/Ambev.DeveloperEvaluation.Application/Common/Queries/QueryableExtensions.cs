using System.Linq.Expressions;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Application.Common.Queries;

public static class QueryableExtensions
{
    /* ---------- Pagination ---------- */
    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int page, int size)
        => query.Skip((Math.Max(page, 1) - 1) * Math.Max(size, 1)).Take(Math.Max(size, 1));

    /* ---------- Ordering ---------- */
    public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, string? order)
    {
        if (string.IsNullOrWhiteSpace(order)) return query;

        IOrderedQueryable<T>? ordered = null;
        var clauses = order.Split(',', StringSplitOptions.RemoveEmptyEntries)
                           .Select(c => c.Trim());

        foreach (var (clause, index) in clauses.Select((c, i) => (c, i)))
        {
            var parts = clause.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var jsonPath = parts[0];                       // ex: "price" ou "rating.rate"
            var desc = parts.Length > 1 && parts[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

            var propExpr = BuildPropertyExpression<T>(jsonPath);
            if (propExpr is null) continue;

            if (index == 0)
                ordered = desc ? Queryable.OrderByDescending(query, (dynamic)propExpr)
                                : Queryable.OrderBy(query, (dynamic)propExpr);
            else
                ordered = desc ? Queryable.ThenByDescending(ordered!, (dynamic)propExpr)
                                : Queryable.ThenBy(ordered!, (dynamic)propExpr);
        }

        return ordered ?? query;
    }

    /* ---------- Filters ---------- */
    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, IDictionary<string, string> filters)
    {
        foreach (var kv in filters)
        {
            var key = kv.Key;
            var value = kv.Value;

            // _minX / _maxX (numérico/data)
            if (key.StartsWith("_min", StringComparison.OrdinalIgnoreCase) ||
                key.StartsWith("_max", StringComparison.OrdinalIgnoreCase))
            {
                var propJson = key.StartsWith("_min", StringComparison.OrdinalIgnoreCase)
                    ? key.Substring(4)   // remove "_min"
                    : key.Substring(4);  // remove "_max"

                var propExpr = BuildPropertyExpression<T>(propJson);
                if (propExpr is null) continue;

                var propType = GetUnderlyingType(propExpr.ReturnType);
                var typedValue = ChangeType(value, propType);
                if (typedValue is null) continue;

                var param = propExpr.Parameters[0];
                var body = key.StartsWith("_min", StringComparison.OrdinalIgnoreCase)
                    ? Expression.GreaterThanOrEqual(propExpr.Body, Expression.Constant(typedValue, propExpr.ReturnType))
                    : Expression.LessThanOrEqual(propExpr.Body, Expression.Constant(typedValue, propExpr.ReturnType));

                var lambda = Expression.Lambda<Func<T, bool>>(body, param);
                query = query.Where(lambda);
                continue;
            }

            // Igualdade / wildcard em string
            {
                var propExpr = BuildPropertyExpression<T>(key);
                if (propExpr is null) continue;

                var param = propExpr.Parameters[0];
                if (propExpr.ReturnType == typeof(string))
                {
                    var raw = value ?? string.Empty;
                    var starts = raw.EndsWith("*");
                    var ends = raw.StartsWith("*");
                    var clean = raw.Trim('*');

                    MethodInfo method;
                    if (starts && ends) method = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!;
                    else if (starts) method = typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string) })!;
                    else if (ends) method = typeof(string).GetMethod(nameof(string.EndsWith), new[] { typeof(string) })!;
                    else
                    {
                        var eq = Expression.Equal(propExpr.Body, Expression.Constant(clean, typeof(string)));
                        var eqLambda = Expression.Lambda<Func<T, bool>>(eq, param);
                        query = query.Where(eqLambda);
                        continue;
                    }

                    var call = Expression.Call(propExpr.Body, method, Expression.Constant(clean));
                    var lambda = Expression.Lambda<Func<T, bool>>(call, param);
                    query = query.Where(lambda);
                }
                else
                {
                    var targetType = GetUnderlyingType(propExpr.ReturnType);
                    var typedValue = ChangeType(value, targetType);
                    if (typedValue is null) continue;

                    var eq = Expression.Equal(propExpr.Body, Expression.Constant(typedValue, propExpr.ReturnType));
                    var lambda = Expression.Lambda<Func<T, bool>>(eq, param);
                    query = query.Where(lambda);
                }
            }
        }

        return query;
    }

    /* ---------- Helpers ---------- */

    // Converte "rating.rate" (json) -> expressão x => x.Rating.Rate (C#)
    private static LambdaExpression? BuildPropertyExpression<T>(string jsonPath)
    {
        if (string.IsNullOrWhiteSpace(jsonPath)) return null;

        // jsonPath vem no formato do JSON (camelCase). Convertemos para PascalCase simples.
        var parts = jsonPath.Split('.', StringSplitOptions.RemoveEmptyEntries)
                            .Select(p => char.ToUpperInvariant(p[0]) + p[1..]);

        var param = Expression.Parameter(typeof(T), "x");
        Expression body = param;

        foreach (var pascal in parts)
        {
            var prop = body.Type.GetProperty(pascal, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop is null) return null;
            body = Expression.Property(body, prop);
        }

        var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), body.Type);
        return Expression.Lambda(delegateType, body, param);
    }

    private static Type GetUnderlyingType(Type t)
        => Nullable.GetUnderlyingType(t) ?? t;

    private static object? ChangeType(string raw, Type target)
    {
        try
        {
            if (target == typeof(DateTime)) return DateTime.Parse(raw);
            if (target == typeof(DateOnly)) return DateOnly.Parse(raw);
            if (target == typeof(Guid)) return Guid.Parse(raw);
            if (target.IsEnum) return Enum.Parse(target, raw, ignoreCase: true);
            return Convert.ChangeType(raw, target);
        }
        catch { return null; }
    }
}
