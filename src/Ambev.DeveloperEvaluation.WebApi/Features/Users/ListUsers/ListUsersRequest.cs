using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

public class ListUsersRequest
{
    [FromQuery(Name = "_page")] 
    public int Page { get; set; } = 1;
    
    [FromQuery(Name = "_size")] 
    public int Size { get; set; } = 10;
    
    [FromQuery(Name = "_order")] 
    public string? Order { get; set; }

    // Suporte para filtros de intervalo em campos numéricos
    [FromQuery(Name = "_minAge")]
    public int? MinAge { get; set; }

    [FromQuery(Name = "_maxAge")]
    public int? MaxAge { get; set; }

    // Dicionário para armazenar filtros dinâmicos
    internal Dictionary<string, string> Filters { get; set; } = new();
}
