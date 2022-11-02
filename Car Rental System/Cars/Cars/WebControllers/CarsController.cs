using Cars.ModelsDB;
using Cars.Repositories;

namespace Cars.WebControllers
{
    public class CarsController
    {
        private readonly ICarsRepository _carsRepository;

        public CarsController(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public List<Car> GetAllCars()
        {
            return _carsRepository.FindAll();
        }
    }
}
