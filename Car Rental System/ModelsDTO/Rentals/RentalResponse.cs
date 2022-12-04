using ModelsDTO.Cars;
using ModelsDTO.Payments;

namespace ModelsDTO.Rentals;

public class RentalResponse
{
    public Guid RentalUid { get; set; }
    public string Status { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public CarInfo Car { get; set; }
    public PaymentInfo Payment { get; set; }
}