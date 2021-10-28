using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] //this means that all methods in this controller will be under the name of the controller i.e. weatherforecast
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /* this specifies the path after weatherforecast/
   so it will become weatherforecast/current/value
        whatever the value being passed is, it will be passed through the method signature 'Get' i.e. [FromRoute] int min

        weatherforecast/current/1?max=20   the ?max=20 is the [FromQuery] this is known as a query string
        */
        [HttpGet("current/{min}")] 
        public IEnumerable<WeatherForecast> Get([FromRoute] int min, [FromQuery]int max )
        {
            var rng = new Random();//creating instance of random object

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(min, max),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }



        /*This is a post request to the api with [FromBody] signature */
        [HttpPost]
        public string Post([FromBody] string str) {

            return str;
        }
    }
}
