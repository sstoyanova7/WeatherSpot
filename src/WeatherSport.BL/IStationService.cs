namespace WeatherSpot.BL
{
    using System.Collections.Generic;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public interface IStationService
    {
        public IEnumerable<RegionResponseModel> GetRegions();
        public ResponseWithMessage AddNewRegion(string name);
        public IEnumerable<CityResponseModel> GetCities(int? regionId = null);
        public ResponseWithMessage AddNewCity(NewCityRequestModel request);
        public IEnumerable<StationsResponseMoedl> GetStations(int? cityId = null);
        public ResponseWithMessage AddNewStation(NewStationRequestModel request);
    }
}
