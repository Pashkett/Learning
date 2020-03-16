using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryManager repository;

        public WeatherForecastController(IRepositoryManager repositoryManager)
        {
            repository = repositoryManager;
        }

        [Route("[controller]")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //private ILoggerManager logger;
        //public WeatherForecastController(ILoggerManager logger)
        //{
        //    this.logger = logger;
        //}

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    logger.LogInfo("Here is info message from our values controller.");
        //    logger.LogDebug("Here is info message from our values controller.");
        //    logger.LogWarn("Here is info message from our values controller.");
        //    logger.LogError("Here is info message from our values controller.");

        //    return new string[] { "value1", "value2" }; 
        //}

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
