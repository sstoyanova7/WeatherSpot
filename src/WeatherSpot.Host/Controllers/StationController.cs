namespace WeatherSpot.Host.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WeatherSpot.BL;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    [ApiController]
    [Route("api/[controller]/")]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        [Route("getRegions")]
        public IEnumerable<RegionModel> GetRegions(int regionId)
        {
            return _stationService.GetRegions(regionId);
        }

        [HttpPost]
        [Route("addNewRegion")]
        public ResponseWithMessage AddNewRegion([FromBody] string name)
        {
            return _stationService.AddNewRegion(name);
        }

        [HttpDelete]
        [Route("deleteRegion")]
        public ResponseWithMessage DeleteRegion(int regionId)
        {
            return _stationService.DeleteRegion(regionId);
        }

        [HttpGet]
        [Route("getCities")]
        public IEnumerable<CityModel> GetCities(int regionId, int cityId)
        {
            return _stationService.GetCities(regionId, cityId);
        }

        [HttpPost]
        [Route("addNewCity")]
        public ResponseWithMessage AddNewCity([FromBody] NewCityRequestModel request)
        {
            return _stationService.AddNewCity(request);
        }

        [HttpDelete]
        [Route("deleteCity")]
        public ResponseWithMessage DeleteCity(int cityId)
        {
            return _stationService.DeleteCity(cityId);
        }

        [HttpGet]
        [Route("getStations")]
        public IEnumerable<StationsResponseMoedl> GetStations(int regionId, int cityId, int stationId)
        {
            return _stationService.GetStations(regionId, cityId, stationId);
        }

        [HttpPost]
        [Route("addNewStation")]
        public ResponseWithMessage AddNewStation([FromBody] NewStationRequestModel request)
        {
            return _stationService.AddNewStation(request);
        }

        [HttpDelete]
        [Route("deleteStation")]
        public ResponseWithMessage DeleteStation(int stationId)
        {
            return _stationService.DeleteStation(stationId);
        }
    }
}
