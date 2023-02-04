using System;
using data_aggregation.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace data_aggregation.Repository
{
	public class ApartmentAggregatorRepository:IApartmentAggregatorRepository
	{
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ApartmentAggregatorRepository> _logger;

        public ApartmentAggregatorRepository(ApplicationDbContext db, ILogger<ApartmentAggregatorRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<ApartmentAggregated>> GetApartments()
        {
            var apartments = await _db.ApartmentsAggregated.ToListAsync();
            _logger.LogInformation("got apartments from database {DT}", DateTime.UtcNow.ToLongTimeString());

            return apartments;
        }
       
        public async Task StoreAggregateApartmentData()
        {
            var query = from a in _db.Apartments
                        group a by a.Network into g
                        select new ApartmentAggregated
                        {
                            Network = g.Key,
                            PPlusSum = g.Sum(a => a.PPlus),
                            PMinusSum = g.Sum(a => a.PMinus),
                        };


            var l = new List<ApartmentAggregated>();
            foreach (var apartment in query)
            {
                l.Add(apartment);
            }

            await _db.ApartmentsAggregated.AddRangeAsync(l);
            await _db.SaveChangesAsync();
            
            _logger.LogInformation("aggregated apartments data has been stored successfully {DT}", DateTime.UtcNow.ToLongTimeString());
        }

        public bool IsDbAlreadySeeded()
        {
            if (_db.Apartments.Any())
            {
                return true;
            }
            return false;
        }
    }
}

