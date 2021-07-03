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

        public IEnumerable<RegionModel> GetRegions(int regionId)
        {
            if(regionId != 0)
            {
                return _stationDal.GetRegion(regionId);
            }

            return _stationDal.GetRegions();
        }

        public ResponseWithMessage AddNewRegion(string name)
        {
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

        public ResponseWithMessage DeleteRegion(int regionId)
        {
            try
            {
                var isDeleted = _stationDal.DeleteRegion(regionId);
                if (isDeleted)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "The region was deleted successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't delete region!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to delete region. {ex.Message}");
            }
        }

        public IEnumerable<CityModel> GetCities(int regionId, int cityId)
        {
            if(cityId != 0)
            {
                return _stationDal.GetCity(cityId);
            }
            if (regionId != 0)
            {
                return _stationDal.GetCitiesByRegionId(regionId);
            }
            else
            {
                return _stationDal.GetCities();
            }
        }

        public ResponseWithMessage AddNewCity(NewCityRequestModel request)
        {
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
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to add new city. {ex.Message}");
            }
        }

        public ResponseWithMessage DeleteCity(int cityId)
        {
            try
            {
                var isDeleted = _stationDal.DeleteCity(cityId);
                if (isDeleted)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "The city was deleted successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't delete city!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to delete city. {ex.Message}");
            }
        }

        public IEnumerable<StationsResponseMoedl> GetStations(int regionId, int cityId, int stationId)
        {
            if(stationId != 0)
            {
                return _stationDal.GetStation(stationId);                
            }

            if (cityId != 0)
            {
                return _stationDal.GetStationsByCityId(cityId);                
            }

            if (regionId != 0)
            {
                return _stationDal.GetStationsByRegionId(regionId);
            }

            return _stationDal.GetStations();


        }

        public ResponseWithMessage AddNewStation(NewStationRequestModel request)
        {
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
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to add new station. {ex.Message}");
            }
        }

        public ResponseWithMessage DeleteStation(int stationId)
        {
            try
            {
                var isDeleted = _stationDal.DeleteStation(stationId);
                if (isDeleted)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "The station was deleted successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't delete station!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to delete station. {ex.Message}");
            }
        }
    }
}
