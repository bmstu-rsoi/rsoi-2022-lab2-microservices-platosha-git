using System.Runtime.Serialization;

namespace ModelsDTO.Payments;

public enum PaymentStatus
{ 
    [EnumMember(Value = "PAID")]
    Paid = 0,

    [EnumMember(Value = "REVERSED")]
    Reversed = 1
}