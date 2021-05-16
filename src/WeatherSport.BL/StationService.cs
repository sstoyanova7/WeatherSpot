namespace WeatherSpot.BL
{
    using System;
    using System.Collections.Generic;
    using WeatherSpot.DataLayer;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public class StationService : IStationService
    {
        private readonly StationDataLayer _stationDal;

        public StationService(StationDataLayer stationDal)
        {
            _stationDal = stationDal;
        }

        public IEnumerable<RegionResponseModel> GetRegions()
        {
            return _stationDal.GetRegions();
        }

        public ResponseWithMessage AddNewRegion(string name)
        {
            //TODO
            //Validate
            var result = _stationDal.AddNewRegion(name);
            //return response
            throw new NotImplementedException();
        }

        public IEnumerable<CityResponseModel> GetCities(int? regionId = null)
        {
            if (regionId == null)
            {
                return _stationDal.GetCities();
            }
            else
            {
                return _stationDal.GetCitiesByRegionId((int)regionId);
            }
        }

        public ResponseWithMessage AddNewCity(NewCityRequestModel request)
        {
            //TODO
            //Validate          
            var result = _stationDal.AddNewCity(request);
            //return response
            throw new NotImplementedException();
            throw new NotImplementedException();
        }

        //TO DO: GetStationsByRegionId
        public IEnumerable<StationsResponseMoedl> GetStations(int? cityId = null)
        {
            if (cityId == null)
            {
                return _stationDal.GetStations();
            }
            else
            {
                return _stationDal.GetStationsByCityId((int)cityId);
            }
        }
              
        public ResponseWithMessage AddNewStation(NewStationRequestModel request)
        {
            //TODO
            //Validate           
            var result = _stationDal.AddNewStation(request);
            //return response
            throw new NotImplementedException();
            throw new NotImplementedException();
        }
    }
}
