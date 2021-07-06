namespace WeatherSpot.Host.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WeatherSpot.BL;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    [ApiController]
    [Route("api/[controller]/")]
    public class StationDataController : ControllerBase
    {
        private readonly IStationDataService _stationDataService;

        public StationDataController(IStationDataService stationDataService)
        {
            _stationDataService = stationDataService;
        }

        [HttpGet]
        [Route("getStationData")]
        public IEnumerable<StationData> GetStationData(int regionId, int cityId, int month, int year)
        {
            return _stationDataService.GetStationData(regionId, cityId, month, year);
        }

        [HttpPost]
        [Route("addStationData")]
        public ResponseWithMessage AddStationData([FromBody] StationDataRequestModel request)
        {
            return _stationDataService.AddStationData(request);
        }
        
        [HttpPost]
        [Route("updateStationData")]
        public ResponseWithMessage UpdateStationData([FromBody] UpdateStationDataRequestModel request)
        {
            return _stationDataService.UpdateStationData(request);
        }

        [HttpDelete]
        [Route("deleteStationData")]
        public ResponseWithMessage DeleteStationData(int stationDataId)
        {
            return _stationDataService.DeleteStationData(stationDataId);
        }       
    }
}
