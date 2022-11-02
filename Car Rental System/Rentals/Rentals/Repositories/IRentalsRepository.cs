using Rentals.ModelsDB;

namespace Rentals.Repositories
{
    public enum ExitCode
    {
        Success,
        Error
    }
    
    public interface IRentalsRepository
    {
        List<Rental> FindAll();
    }
}
