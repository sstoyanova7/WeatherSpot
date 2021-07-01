namespace WeatherSpot.BL
{
    using System;
    using System.Collections.Generic;
    using System.Net;
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

        public IEnumerable<RegionModel> GetRegions()
        {
            return _stationDal.GetRegions();
        }

        public ResponseWithMessage AddNewRegion(string name)
        {
            //TODO
            //Validate
            try
            {
                var isAdded = _stationDal.AddNewRegion(name);
                if (isAdded)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "New region was added successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't add new region!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to add new region. {ex.Message}");
            }
        }

        public IEnumerable<CityModel> GetCities(int? regionId = null)
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
            try
            {
                var isAdded = _stationDal.AddNewCity(request);
                if (isAdded)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "New city was added successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't add new city!");
                }
            }
            catch(Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to add new city. {ex.Message}");
            }
        }
        
        //TO DO: GetStationsByRegionId ?
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
            try
            {
                var isAdded = _stationDal.AddNewStation(request);
                if (isAdded)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "New station was added successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't add new station!");
                }
            }
            catch(Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to add new station. {ex.Message}");
            }
        }
    }
}
