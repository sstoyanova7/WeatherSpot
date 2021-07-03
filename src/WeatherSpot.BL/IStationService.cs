namespace WeatherSpot.BL
{
    using System.Collections.Generic;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public interface IStationService
    {
        public IEnumerable<RegionModel> GetRegions(int regionId);
        public ResponseWithMessage AddNewRegion(string name);
        public ResponseWithMessage DeleteRegion(int regionId);

        public IEnumerable<CityModel> GetCities(int regionId, int cityId);
        public ResponseWithMessage AddNewCity(NewCityRequestModel request);
        public ResponseWithMessage DeleteCity(int cityId);
        public IEnumerable<StationsResponseMoedl> GetStations(int regionId, int cityId, int stationId);
        public ResponseWithMessage AddNewStation(NewStationRequestModel request);
        public ResponseWithMessage DeleteStation(int stationId);
    }
}
