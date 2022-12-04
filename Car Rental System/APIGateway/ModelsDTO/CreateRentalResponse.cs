using System.Runtime.Serialization;
using ModelsDTO.Payments;

namespace APIGateway.ModelsDTO;

public enum RentalStatusCreate
{ 
    [EnumMember(Value = "IN_PROGRESS")]
    InProgress = 0,
    
    [EnumMember(Value = "FINISHED")]
    Finished = 1,
    
    [EnumMember(Value = "CANCELED")]
    Canceled = 2
}

public class CreateRentalResponse
{
    public Guid RentalUid { get; set; }
    public RentalStatusCreate Status { get; set; }
    public Guid CarUid { get; set; }
    public DateTimeOffset DateFrom { get; set; }
    public DateTimeOffset DateTo { get; set; }
    public PaymentInfo Payment { get; set; }
}