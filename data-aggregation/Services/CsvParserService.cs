using System;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using data_aggregation.Models.Apartment;
using data_aggregation.Models.Exceptions;
using data_aggregation.Services;

namespace data_aggregation
{
	public class CsvParserService:ICsvParserService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<CsvParserService> _logger;

        public CsvParserService(ApplicationDbContext db, ILogger<CsvParserService> logger)
		{
            _db = db;
            _logger = logger;
        }

        private Apartment InitApartment(ApartmentCsv info)
        {
            _logger.LogInformation("Initializing apartment object {DT}", DateTime.UtcNow.ToLongTimeString());

            return new Apartment
            {
                Id = Guid.NewGuid().ToString(),
                Network = info.Network,
                ObtName = info.ObtName,
                ObjNumber = info.ObjNumber,
                ObjGvType = info.ObjGvType,
                PPlus = string.IsNullOrEmpty(info.PPlus)? 0 : decimal.Parse(info.PPlus, CultureInfo.InvariantCulture.NumberFormat),
                PlTime = info.PlTime,
                PMinus = string.IsNullOrEmpty(info.PMinus)? 0 : decimal.Parse(info.PMinus, CultureInfo.InvariantCulture.NumberFormat),
            };
        }

        public async Task ConvertCsvToObject(string? dir)
        {
            _logger.LogInformation("started reading csv files {DT}", DateTime.UtcNow.ToLongTimeString());
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            var records = new List<ApartmentCsv>();

            if (dir == null)
            {
                _logger.LogInformation("invalid directory for csv file {DT}", DateTime.UtcNow.ToLongTimeString());
                throw new NullReferenceException("invalid file directory");
            }

            using (var reader = new StreamReader(dir))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ApartmentInfoMap>();
                records = csv.GetRecords<ApartmentCsv>().ToList();
            }

            var apartmentData = new List<Apartment>();
            foreach (var record in records)
            {
                apartmentData.Add(InitApartment(record));
            }

            _logger.LogInformation("converted csv file data into Apartment object {DT}",
                DateTime.UtcNow.ToLongTimeString());
            await _db.BulkInsertAsync(apartmentData);
            _logger.LogInformation("database has been seeded with data that was rad from file {DT}",
                DateTime.UtcNow.ToLongTimeString());

        }
    }
}


