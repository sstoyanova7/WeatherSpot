using System.Collections.Generic;
using WeatherSpot.Models.RequestModels;
using WeatherSpot.Models.ResponseModels;

namespace WeatherSpot.BL
{
    public interface IStationDataService
    {
        public IEnumerable<StationData> GetStationData(int regionId, int cityId, int month, int year);
        public ResponseWithMessage AddStationData(StationDataRequestModel request);
        public ResponseWithMessage UpdateStationData(UpdateStationDataRequestModel request);
        public ResponseWithMessage DeleteStationData(int stationDataId);    
    }
}
