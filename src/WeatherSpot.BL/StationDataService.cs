using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WeatherSpot.DataLayer;
using WeatherSpot.Models.RequestModels;
using WeatherSpot.Models.ResponseModels;

namespace WeatherSpot.BL
{

    public class StationDataService : IStationDataService
    {
        private readonly IMapper _mapper;
        private readonly StationDataDataLayer _stationDataDal;

        public StationDataService(IMapper mapper, 
            StationDataDataLayer stationDataDal)
        {
            _mapper = mapper;
            _stationDataDal = stationDataDal;
        }

        public IEnumerable<StationData> GetStationData(int cityId, int month, int year)
        {
            var stationsDataFromDb = _stationDataDal.GetStationsData(cityId, month, year);
            return stationsDataFromDb.Select(s => _mapper.Map<StationData>(s));
        }

        public ResponseWithMessage AddStationData(StationDataRequestModel request)
        {
            return _stationDataDal.AddStationData(request);
            //todo recalculate weights!
        }

        public ResponseWithMessage UpdateStationData(UpdateStationDataRequestModel request)
        {
            //todo recalculate weights!
            return _stationDataDal.UpdateStationData(request);
        }

        public ResponseWithMessage DeleteStationData(int stationDataId)
        {
            //todo recalculate weights!

            try
            {
                var isDeleted = _stationDataDal.DeleteStationData(stationDataId);
                if (isDeleted)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "Station data was deleted successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't delete station data!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to delete station data. {ex.Message}");
            }
        }
    }
}
