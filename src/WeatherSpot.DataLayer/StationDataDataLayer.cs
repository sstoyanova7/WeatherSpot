namespace WeatherSpot.DataLayer
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Net;
    using WeatherSpot.Models.DbResponseModels;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public class StationDataDataLayer
    {
        private readonly string _connectionString;
        public StationDataDataLayer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<StationDataDbModel> GetStationsData(int cityId, int month, int year)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
				  @"SELECT s.Id as StationDataId, 
	s.StationId as StationDataId,
	s.Month as Month,
	s.Year as Year,
	s.Weight as Weight,
	td.Average as AverageTemperature,
	td.Delta as DeltaTemperature, 
	td.Min as MinTemperature,
	td.Max as MaxTemperature,
	td.DayMin as DayMinTemperature, 
	td.DayMax as DayMaxTemperature,
	rd.Total as TotalRain,
	rd.QQN as QQNRain,
	rd.Max as MaxRain,
	rd.DayMax as DayMaxRain,
	sd.DaysRainOver1mm as DaysRainOver1mm,
	sd.DaysRainUnder1mm as DaysRainUnder1mm,
	sd.DaysWindOver14ms as DaysWindOver14ms,
	sd.DaysThunderbolts as DaysThunderbolts,
	c.Id as CityId,
	c.RegionId as RegionId
FROM StationData s
INNER JOIN TemperatureData td ON s.Id = td.StationDataId
INNER JOIN RainData rd ON s.Id = rd.StationDataId
INNER JOIN StatisticsData sd ON s.Id = sd.StationDataId
INNER JOIN Stations st ON s.StationId = st.Id
INNER JOIN Cities c ON s.StationId = st.CityId
WHERE Month=@Month AND Year=@Year AND CityId =@CityId";


                var parameters = new
                {
                    CityId = cityId,
                    Month = month,
                    Year = year
                };

                return con.Query<StationDataDbModel>(query, parameters);
            }
        }

		public ResponseWithMessage AddStationData(NewStationDataRequestModel request)
		{
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var query =
                        @"INSERT INTO StationData(StationId, Month, Year, Weight) 
VALUES(@StationId, @Month, @Year, @Weight)

SELECT CAST(SCOPE_IDENTITY() as int)";

                    var parameters = new
                    {
                        StationId = request.StationId,
                        Month = request.Month,
                        Year = request.Year,
                        Weight = request.Weight
                    };

                    var stationDataId = con.QuerySingle<int>(query, parameters);

                    query =
    @"INSERT INTO TemperatureData(StationDataId, Average, Delta, Max, Min, DayMax, DayMin)
VALUES(@StationDataId, @Average, @Delta, @Max, @Min, @DayMax, @DayMin)";

                    var temperatureParameters = new
                    {
                        StationDataId = stationDataId,
                        Average = request.TemperatureAverage,
                        Delta = request.TemperatureDelta,
                        Max = request.TemperatureMax,
                        Min = request.TemperatureMin,
                        DayMax = request.TemperatureDayMax,
                        DayMin = request.TemperatureDayMin
                    };

                    query =
   @"INSERT INTO RainData(Total, QQN, Max, DayMax)
VALUES(@Total, @QQN, @Max, @DayMax)";

                    var rainParameters = new
                    {
                        StationDataId = stationDataId,
                        Total = request.RainTotal,
                        QQN = request.RainQQn,                      
                        Max = request.RainMax,
                        DayMax = request.RainDayMax,
                    };

                    con.Query(query, rainParameters);

                    query =
@"DaysRainOver1mm, DaysRainUnder1mm, DaysWindOver14ms, DaysThunderbolts)
VALUES(@StationDataId, @DaysRainOver1mm, @DaysRainUnder1mm, @DaysWindOver14ms, @DaysThunderbolts)";

                    var statisticsParameters = new
                    {
                        StationDataId = stationDataId,
                        DaysRainOver1mm = request.DaysRainOver1mm,
                        DaysRainUnder1mm = request.DaysRainUnder1mm,
                        DaysWindOver14ms = request.DaysWindOver14ms,
                        DaysThunderbolts = request.DaysThunderbolts
                    };

                    con.Query(query, statisticsParameters);

                    return new ResponseWithMessage(HttpStatusCode.OK, "StationData added successfully");
                }
            }
            catch(Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, "An error occured");
            }
        }
	}
}
