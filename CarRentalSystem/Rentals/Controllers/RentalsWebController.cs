using Rentals.ModelsDB;
using Rentals.Repositories;

namespace Rentals.Controllers
{
    public class RentalsWebController
    {
        private readonly IRentalsRepository _rentalsRepository;

        public RentalsWebController(IRentalsRepository rentalsRepository)
        {
            _rentalsRepository = rentalsRepository;
        }

        public async Task<List<Rental>> GetAllRentals(int page, int size)
        {
            return await _rentalsRepository.FindAll(page, size);
        }
        
        public async Task<List<Rental>> GetAllRentalsByUsername(string username)
        {
            return await _rentalsRepository.FindByName(username);
        }
        
        public async Task<Rental?> GetRentalByRentalUid(string username, Guid rentalUid)
        {
            return await _rentalsRepository.FindByRentalUid(username, rentalUid);
        }

        public async Task<Rental> AddRental(Rental rental)
        {
            return await _rentalsRepository.Add(rental);
        }
        
        public async Task FinishRent(Rental rental)
        {
            await _rentalsRepository.Patch(rental);
        }
    }
}