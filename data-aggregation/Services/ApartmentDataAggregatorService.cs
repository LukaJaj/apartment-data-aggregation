using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using data_aggregation.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace data_aggregation.Services.Interfaces
{
    public class ApartmentDataAggregatorService : IApartmentDataAggregatorService
    {
		private readonly IApartmentAggregatorRepository _repo;
        
		public ApartmentDataAggregatorService(IApartmentAggregatorRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ApartmentAggregated>> GetApartments()
        {
            return await _repo.GetApartments();
        }

        public async Task StoreAggregateApartmentData()
		{
            await _repo.StoreAggregateApartmentData();
        }

        public bool IsDbAlreadySeeded()
        {
            return  _repo.IsDbAlreadySeeded();
        }
    }
}

