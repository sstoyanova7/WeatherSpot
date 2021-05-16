namespace WeatherSpot.Host.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WeatherSpot.BL;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    [ApiController]
    [Route("[controller]")]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        [Route("api/getRegions")]
        public IEnumerable<RegionResponseModel> GetRegions()
        {
            return _stationService.GetRegions();
        }

        [HttpPost]
        [Route("api/addNewRegion")]
        public ResponseWithMessage AddNewRegion([FromBody] string name)
        {
            return _stationService.AddNewRegion(name);
        }

        //TODO
        //queryparams
        [HttpGet]
        [Route("api/getCities")]
        public IEnumerable<CityResponseModel> GetCities()
        {
            return _stationService.GetCities();
        }

        [HttpPost]
        [Route("api/addNewCity")]
        public ResponseWithMessage AddNewCity([FromBody] NewCityRequestModel request)
        {
            return _stationService.AddNewCity(request);
        }

        //TODO
        //queryparams
        [HttpGet]
        [Route("api/getStations")]
        public IEnumerable<StationsResponseMoedl> GetStations()
        {
            return _stationService.GetStations();
        }

        [HttpPost]
        [Route("api/addNewStation")]
        public ResponseWithMessage AddNewStation([FromBody] NewStationRequestModel request)
        {
            return _stationService.AddNewStation(request);
        }
    }
}
