namespace ModelsDTO.Rentals;

public class RentalsDTO
{
    public Guid RentalUid { get; set; }
    public string Username { get; set; }
    public Guid PaymentUid { get; set; }
    public Guid CarUid { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string Status { get; set; }
}