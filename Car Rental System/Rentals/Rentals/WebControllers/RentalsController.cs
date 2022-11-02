using Rentals.ModelsDB;
using Rentals.Repositories;

namespace Rentals.WebControllers
{
    public class RentalsController
    {
        private readonly IRentalsRepository _rentalsRepository;

        public RentalsController(IRentalsRepository rentalsRepository)
        {
            _rentalsRepository = rentalsRepository;
        }

        public List<Rental> GetAllRentals()
        {
            return _rentalsRepository.FindAll();
        }
    }
}
