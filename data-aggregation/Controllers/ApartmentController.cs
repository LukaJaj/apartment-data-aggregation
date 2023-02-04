using data_aggregation.Models.Exceptions;
using data_aggregation.Services;
using data_aggregation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace data_aggregation.Controllers;

[Route("api/")]
public class ApartmentController : Controller
{
    private readonly ILogger<ApartmentController> _logger;
    private readonly IConfiguration _config;
    private readonly ICsvParserService _csvParser;
    private readonly IApartmentDataAggregatorService _apartmentAggregator;


    public ApartmentController(
        ILogger<ApartmentController> logger,
        IConfiguration config,
        ICsvParserService csvParser,
        IApartmentDataAggregatorService apartmentAggregator
        )
    {
        _config = config;
        _logger = logger;
        _csvParser = csvParser;
        _apartmentAggregator = apartmentAggregator;
    }

    [HttpGet("aggregated-data")]
    public async  Task<List<ApartmentAggregated>> AggregatedData()
    {
        _logger.LogInformation("Getting aggregated apartments data at {DT}", DateTime.UtcNow.ToLongTimeString());
        return await _apartmentAggregator.GetApartments();
    }

    [HttpPost("create-aggregated-data")]
    public async Task<IActionResult> CreateAggregatedData()
    {
        _logger.LogInformation("storing aggregated apartments data into database at {DT}", DateTime.UtcNow.ToLongTimeString());
        await _apartmentAggregator.StoreAggregateApartmentData();
        
        return Ok(StatusCodes.Status200OK);
    }

    [HttpGet("generate")]
    public async Task<IActionResult> Generate()
    {
        if (_apartmentAggregator.IsDbAlreadySeeded())
        {
            throw new TableAlreadySeededException("you have already seeded data");
        }
        
        _logger.LogInformation("entered generate endpoint  at {DT}", DateTime.UtcNow.ToLongTimeString());
        var fileDirs = new List<string?> {
            _config.GetValue<string>("FirstMonthDir"),
            _config.GetValue<string>("SecondMonthDir"),
            _config.GetValue<string>("ThirdMonthDir"),
            _config.GetValue<string>("FourthMonthDir")
        };

        foreach (var fileDir in fileDirs)
        {
            await _csvParser.ConvertCsvToObject(fileDir);
        }
        return Ok(StatusCodes.Status200OK);
    }
}

