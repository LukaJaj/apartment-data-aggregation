using System;
namespace data_aggregation.Services.Interfaces
{
	public interface IApartmentDataAggregatorService
	{
        Task StoreAggregateApartmentData();
		Task<List<ApartmentAggregated>> GetApartments();
        bool IsDbAlreadySeeded();

    }
}

