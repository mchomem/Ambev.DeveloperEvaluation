namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class PaginatedResponse<T> : ApiResponseWithData<IEnumerable<T>>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }

    public static PaginatedResponse<T> FromPaginatedList(Ambev.DeveloperEvaluation.Application.Common.Pagination.PaginatedList<T> list)
      => new()
      {
          Data = list,
          CurrentPage = list.CurrentPage,
          TotalPages = list.TotalPages,
          TotalCount = list.TotalCount,
          Success = true
      };
}
