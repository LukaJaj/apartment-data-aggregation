using System;
namespace data_aggregation.Services
{
	public interface ICsvParserService
	{
        Task ConvertCsvToObject(string? dir);
    }
}

