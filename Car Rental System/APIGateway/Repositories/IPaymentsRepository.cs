using ModelsDTO.Payments;

namespace APIGateway;

public interface IPaymentsRepository
{
    Task<PaymentInfo> GetAsyncByUid(Guid paymentUid);
}