using System;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration.Attributes;


namespace data_aggregation
{
	public class ApartmentCsv
	{
        [CsvHelper.Configuration.Attributes.Index(0)] public string Network { get; set; }

        [CsvHelper.Configuration.Attributes.Index(1)] public string ObtName { get; set; }

        [CsvHelper.Configuration.Attributes.Index(2)] public string ObjGvType { get; set; }

        [CsvHelper.Configuration.Attributes.Index(3)] public string ObjNumber { get; set; }

        [CsvHelper.Configuration.Attributes.Index(4)] public string PPlus { get; set; }

        [CsvHelper.Configuration.Attributes.Index(5)] public string PlTime { get; set; }

        [CsvHelper.Configuration.Attributes.Index(6)] public string PMinus { get; set; }
    }
}

