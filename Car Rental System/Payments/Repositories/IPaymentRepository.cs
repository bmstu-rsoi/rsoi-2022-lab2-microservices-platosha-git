using Payments.ModelsDB;

namespace Payments.Repositories
{
    public interface IPaymentsRepository
    {
        Task<Payment> FindByUid(Guid paymentUid);
    }
}