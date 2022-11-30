﻿using Microsoft.EntityFrameworkCore;
using Rentals.ModelsDB;

namespace Rentals.Repositories
{
    public class RentalsRepository : IRentalsRepository, IDisposable
    {
        private readonly RentalContext _db;
        private readonly ILogger<RentalsRepository> _logger;

        public RentalsRepository(RentalContext createDb, ILogger<RentalsRepository> logDb)
        {
            _db = createDb;
            _logger = logDb;
        }

        public async Task<List<Rental>> FindAll(int page, int size)
        {
            try
            {
                var rentals = await _db.Rentals
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync();
                return rentals;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error while trying to FindAll");
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Rental>> FindByName(string username)
        {
            try
            {
                var rentals = await _db.Rentals
                    .Where(x => x.Username == username)
                    .OrderBy(x => x.Id)
                    .ToListAsync();
                return rentals;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error while trying to FindByName");
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<Rental> FindByRentalUid(string username, Guid RentalUid)
        {
            throw new NotImplementedException();
        }

        /*public async Task<Rental> FindByRentalUid(string username, Guid RentalUid)
        {
            try
            {
                var rentals = await _db.Rentals
                    .Where(x => x.Username == username && x.RentalUid.Equals(RentalUid))
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync();
                return rentals;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "+ Error while trying to FindByName");
                Console.WriteLine(e);
                throw;
            }
        }
        */

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}