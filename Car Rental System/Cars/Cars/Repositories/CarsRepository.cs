using Cars.ModelsDB;

namespace Cars.Repositories
{
    public class CarsRepository : ICarsRepository, IDisposable
    {
        private readonly CarsContext _db;
        private readonly ILogger<CarsRepository> _logger;

        public CarsRepository(CarsContext createDb, ILogger<CarsRepository> logDb)
        {
            _db = createDb;
            _logger = logDb;
        }

        public List<Car> FindAll()
        {
            var cars = _db.Cars.ToList();
            return cars;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
