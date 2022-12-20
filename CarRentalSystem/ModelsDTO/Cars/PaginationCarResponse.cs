namespace ModelsDTO.Cars;

public class PaginationCarResponse
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalElements { get; set; }
    public List<CarResponse> Cars { get; set; }
}