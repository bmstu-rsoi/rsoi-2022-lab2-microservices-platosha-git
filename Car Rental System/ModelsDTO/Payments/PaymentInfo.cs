namespace ModelsDTO.Payments;

public class PaymentInfo
{
    public Guid PaymentUid { get; set; }
    public string Status { get; set; }
    public int Price { get; set; }
}