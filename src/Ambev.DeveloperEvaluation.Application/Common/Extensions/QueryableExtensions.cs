using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Application.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyFilterString<T>(this IQueryable<T> query, string nomeDaPropriedade, string valor)
    {
        if (string.IsNullOrEmpty(valor))
            return query;

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, nomeDaPropriedade);
        
        Expression comparison;
        if (valor.StartsWith("*") && valor.EndsWith("*"))
        {
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            comparison = Expression.Call(property, method!, Expression.Constant(valor.Trim('*')));
        }
        else if (valor.StartsWith("*"))
        {
            var method = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            comparison = Expression.Call(property, method!, Expression.Constant(valor.TrimStart('*')));
        }
        else if (valor.EndsWith("*"))
        {
            var method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            comparison = Expression.Call(property, method!, Expression.Constant(valor.TrimEnd('*')));
        }
        else
        {
            comparison = Expression.Equal(property, Expression.Constant(valor));
        }

        var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);
        return query.Where(lambda);
    }
}