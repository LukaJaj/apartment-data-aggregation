using System;
using data_aggregation;
using data_aggregation.Controllers;
using data_aggregation.Services;
using data_aggregation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace data_aggregation_test
{
	public class ApartmentControllerTest
	{

		private readonly ApartmentController _controller;
        private readonly ILogger<ApartmentController> _logger;
        private readonly IConfiguration _config;
        private readonly ICsvParserService _csvParser;
        private readonly IApartmentDataAggregatorService _service;

        public ApartmentControllerTest()
		{
			_service = new ApartmentDataAggregatorServiceFake();
			_controller = new ApartmentController(_logger, _config, _csvParser, _service);
		}
        
        [Fact]
        public void Get_WhenCalled_ReturnsListOfAggregatedApartmentsResult()
        {
	        _service.StoreAggregateApartmentData();
			var aggregatedApartments = _controller.AggregatedData();
			Assert.Equal(2, aggregatedApartments.Result.Count);
        }
        
        [Fact]
        public void Get_WhenCalled_ReturnsEmptyListResult()
        {
	        var aggregatedApartments = _controller.AggregatedData();
	        Assert.Empty(aggregatedApartments.Result);
        }

	}
}

