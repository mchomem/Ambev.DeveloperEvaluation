namespace Ambev.DeveloperEvaluation.Application.Common.Queries;

public class QueryOptions
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string Order { get; set; } = string.Empty; // ex: "price desc, title asc"
    public Dictionary<string, string> Filters { get; set; } = new();
}
