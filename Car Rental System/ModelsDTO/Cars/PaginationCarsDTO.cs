namespace ModelsDTO.Cars;

public class PaginationCarsDTO
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalElements { get; set; }
    public List<CarsDTO> Cars { get; set; }
}