

namespace DevHorizons.DAL.WebApi.Controllers
{
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using Sql;

    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly ILogger<BrandsController> _logger;
        private readonly Abstracts.Command sqlCmd;
        public BrandsController(ILogger<BrandsController> logger, Abstracts.Command sqlCmd)
        {
            _logger = logger;
            this.sqlCmd = sqlCmd;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet, Route("GetAllBrands")]
        public IEnumerable<Brand> GetAllBrands()
        {
            var sp = "[dbo].[testGetAllBrands]";
            var list = this.sqlCmd.ExecuteQuery<Brand>(sp);
            return list; ;
        }
    }
}