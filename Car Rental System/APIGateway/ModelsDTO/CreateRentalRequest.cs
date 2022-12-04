namespace APIGateway.ModelsDTO;

public class CreateRentalRequest
{
    public Guid CarUid { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}