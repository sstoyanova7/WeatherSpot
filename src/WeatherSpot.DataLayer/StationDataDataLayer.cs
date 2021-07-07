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
	sd.DaysRainOver10mm as DaysRainOver10mm,
	sd.DaysWindOver14ms as DaysWindOver14ms,
	sd.DaysThunderbolts as DaysThunderbolts,
	c.Id as CityId,
	c.RegionId as RegionId
FROM StationData s
INNER JOIN TemperatureData td ON s.Id = td.StationDataId
INNER JOIN RainData rd ON s.Id = rd.StationDataId
INNER JOIN StatisticsData sd ON s.Id = sd.StationDataId
INNER JOIN Stations st ON s.StationId = st.Id
INNER JOIN Cities c ON st.CityId = c.Id
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

		public ResponseWithMessage AddStationData(StationDataRequestModel request)
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

                    con.Query(query, temperatureParameters);

                    query =
   @"INSERT INTO RainData(StationDataId, Total, QQN, Max, DayMax)
VALUES(@StationDataId, @Total, @QQN, @Max, @DayMax)";

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
@"INSERT INTO StatisticsData(StationDataId, DaysRainOver1mm, DaysRainOver10mm, DaysWindOver14ms, DaysThunderbolts)
VALUES(@StationDataId, @DaysRainOver1mm, @DaysRainOver10mm, @DaysWindOver14ms, @DaysThunderbolts)";

                    var statisticsParameters = new
                    {
                        StationDataId = stationDataId,
                        DaysRainOver1mm = request.DaysRainOver1mm,
                        DaysRainOver10mm = request.DaysRainOver10mm,
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

        public ResponseWithMessage UpdateStationData(UpdateStationDataRequestModel request)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var query =
                        @"UPDATE StationData
SET Weight = @Weight,
Where Id = @StationDataId

UPDATE TemperatureData
SET Average = @TemperatureAverage,
Delta = @TemperatureDelta,
Max = @TemperatureMax,
Min = @TemperatureMin,
DayMax = @TemperatureDayMax,
DayMin = @TemperatureDayMin
Where StationDataId = @StationDataId

UPDATE RainData
SET Total = @RainTotal,
QQN = @RainQQn,
Max = @RainMax,
DayMax = @RainDayMax
Where StationDataId = @StationDataId

UPDATE StatisticsData
SET DaysRainOver1mm = @DaysRainOver1mm,
DaysRainOver10mm = @DaysRainOver10mm,
DaysWindOver14ms = @DaysWindOver14ms,
DaysThunderbolts = @DaysThunderbolts
Where StationDataId = @StationDataId";

                    var parameters = new
                    {
                        StationId = request.StationDataId,
                        Weight = request.Weight,
                        TemperatureAverage = request.TemperatureAverage,
                        TemperatureDelta = request.TemperatureDelta,
                        TemperatureMax = request.TemperatureMax,
                        TemperatureMin = request.TemperatureMin,
                        TemperatureDayMax = request.TemperatureDayMax,
                        TemperatureDayMin = request.TemperatureDayMin,
                        RainTotal = request.RainTotal,
                        RainQQn = request.RainQQn,
                        RainMax = request.RainMax,
                        RainDayMax = request.RainDayMax,
                        DaysRainOver1mm = request.DaysRainOver1mm,
                        DaysRainOver10mm = request.DaysRainOver10mm,
                        DaysWindOver14ms = request.DaysWindOver14ms,
                        DaysThunderbolts = request.DaysThunderbolts,
                    };

                    con.Query<int>(query, parameters);

                    return new ResponseWithMessage(HttpStatusCode.OK, "Station data updated successfully");
                }
                 
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, "An error occured");
            }
        }

        public bool DeleteStationData(int stationDataId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    @"DELETE FROM TemperatureData Where StationDataId = @StationDataId
DELETE FROM RainData Where StationDataId = @StationDataId
DELETE FROM StatisticsData Where StationDataId = @StationDataId
DELETE FROM StationData Where Id = @StationDataId";

                var parameters = new
                {
                    StationDataId = stationDataId
                };

                var deletedRows = con.Execute(query, parameters);

                return deletedRows > 0;
            }
        }
    }
}
