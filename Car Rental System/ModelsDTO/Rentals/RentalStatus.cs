using System.Runtime.Serialization;

namespace ModelsDTO.Rentals;

public enum RentalStatus
{ 
    [EnumMember(Value = "NEW")]
    New = 0,
    
    [EnumMember(Value = "IN_PROGRESS")]
    InProgress = 1,
    
    [EnumMember(Value = "FINISHED")]
    Finished = 2,
    
    [EnumMember(Value = "CANCELED")]
    Canceled = 3,
}