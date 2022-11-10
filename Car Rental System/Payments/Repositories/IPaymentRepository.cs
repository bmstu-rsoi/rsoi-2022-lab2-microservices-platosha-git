using Payments.ModelsDB;

namespace Payments.Repositories
{
    public enum ExitCode
    {
        Success,
        Error
    }

    public interface IPaymentsRepository
    {
        List<Payment> FindAll();
    }
}