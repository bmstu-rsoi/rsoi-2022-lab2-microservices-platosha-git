using Cars.ModelsDB;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Car>> FindAll(int page, int size)
        {
            try
            {
                var cars = await _db.Cars
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync();
                return cars;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error while trying to FindAll");
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<List<Car>> FindAvailable(int page, int size)
        {
            try
            {
                var cars = await _db.Cars
                    .Where(x => x.Availability == true)
                    .OrderBy(x => x.Price)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync();
                return cars;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error while trying to FindAvailable");
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}