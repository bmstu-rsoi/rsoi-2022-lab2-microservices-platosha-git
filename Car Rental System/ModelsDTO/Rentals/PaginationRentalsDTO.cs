namespace ModelsDTO.Rentals;

public class PaginationRentalsDTO
{
    public int TotalElements { get; set; }
    public List<RentalsDTO> Rentals { get; set; }
}