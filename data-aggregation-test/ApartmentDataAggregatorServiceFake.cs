using System;
using data_aggregation;
using data_aggregation.Services.Interfaces;

namespace data_aggregation_test
{
	public class ApartmentDataAggregatorServiceFake: IApartmentDataAggregatorService
	{
        private readonly List<ApartmentAggregated> apartmentsAggregated;
        private readonly List<Apartment> apartments;

        public ApartmentDataAggregatorServiceFake()
		{
            apartmentsAggregated = new List<ApartmentAggregated>();
            apartments = new List<Apartment>()
            {
                new Apartment
                {
                    Id = "000014ae-e83e-40a4-b542-97db002c2ad8",
                    Network = "Panevėžio regiono tinklas",
                    ObtName = "Namas",
                    ObjGvType = "N",
                    ObjNumber = "238966",
                    PPlus = (decimal) 12.21f,
                    PMinus = (decimal) 34.54f
                },
                new Apartment
                {
                    Id = "000168fb-4527-487f-b155-d2376c9a37c4",
                    Network = "Kauno regiono tinklas",
                    ObtName = "Butas",
                    ObjGvType = "Ne GV",
                    ObjNumber = "16051042",
                    PPlus = (decimal) 0.44f,
                    PMinus = (decimal) 4.19f
                },
            };
        }
        public Task<List<ApartmentAggregated>> GetApartments()
        {
            return Task.FromResult(apartmentsAggregated);
        }

        public bool IsDbAlreadySeeded()
        {
            return true;
        }

        public Task StoreAggregateApartmentData()
        {
            foreach (var item in apartments)
            {
                apartmentsAggregated.Add(Aggregated(item));
            }

            return Task.FromResult(apartmentsAggregated);
        }
        
        private ApartmentAggregated Aggregated(Apartment apartment)
        {
            return new ApartmentAggregated
            {
                Network = apartment.Network,
                PPlusSum = apartment.PPlus,
                PMinusSum = apartment.PMinus
            };
        }

        
    }
}

