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

        public List<Rental> GetAllRentals()
        {
            return _rentalsRepository.FindAll();
        }
    }
}