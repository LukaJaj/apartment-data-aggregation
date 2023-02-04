using System;
namespace data_aggregation.Repository.Interfaces
{
	public interface IApartmentAggregatorRepository
	{
        Task StoreAggregateApartmentData();
        Task<List<ApartmentAggregated>> GetApartments();
        bool IsDbAlreadySeeded();
    }
}

