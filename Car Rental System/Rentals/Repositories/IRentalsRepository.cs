using Rentals.ModelsDB;

namespace Rentals.Repositories
{
    public interface IRentalsRepository
    {
        Task<List<Rental>> FindAll(int page, int size);
        Task<List<Rental>> FindByName(string username);
        Task<Rental?> FindByRentalUid(string username, Guid rentalUid);
    }
}