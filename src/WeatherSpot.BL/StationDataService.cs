using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<StationData> GetStationData(int regionId, int cityId, int month, int year)
        {
            var stationsDataFromDb = _stationDataDal.GetStationsData(cityId, month, year);
            return stationsDataFromDb.Select(s => _mapper.Map<StationData>(s));
        }

        public ResponseWithMessage AddStationData(NewStationDataRequestModel request)
        {
            return _stationDataDal.AddStationData(request);
            //todo recalculate weights!
        }

        public ResponseWithMessage UpdateStationData(UpdateStationDataRequestModel request)
        {
            //todo recalculate weights!
            throw new NotImplementedException();
        }

        public ResponseWithMessage DeleteStationData(int stationDataId)
        {
            //todo recalculate weights!
            throw new NotImplementedException();
        }
    }
}
