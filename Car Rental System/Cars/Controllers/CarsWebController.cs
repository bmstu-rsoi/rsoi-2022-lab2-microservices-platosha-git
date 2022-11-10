using Cars.ModelsDB;
using Cars.Repositories;

namespace Cars.Controllers
{
    public class CarsWebController
    {
        private readonly ICarsRepository _carsRepository;

        public CarsWebController(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public List<Car> GetAllCars()
        {
            return _carsRepository.FindAll();
        }
    }
}