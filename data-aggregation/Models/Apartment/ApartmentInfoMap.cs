using System;
using CsvHelper.Configuration;

namespace data_aggregation.Models.Apartment
{
    public sealed class ApartmentInfoMap : ClassMap<ApartmentCsv>
    {
        public ApartmentInfoMap()
        {
            Map<ApartmentCsv>(p => p.Network).Index(0);
            Map<ApartmentCsv>(p => p.ObtName).Index(1);
            Map<ApartmentCsv>(p => p.ObjGvType).Index(2);
            Map<ApartmentCsv>(p => p.ObjNumber).Index(3);
            Map<ApartmentCsv>(p => p.PPlus).Index(4);
            Map<ApartmentCsv>(p => p.PlTime).Index(5);
            Map<ApartmentCsv>(p => p.PMinus).Index(6);
        }
    }
}

