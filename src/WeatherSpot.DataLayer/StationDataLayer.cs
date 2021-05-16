namespace WeatherSpot.DataLayer
{
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using WeatherSpot.Models.ResponseModels;
    using Dapper;
    using System.Data.SqlClient;
    using WeatherSpot.Models.RequestModels;

    public class StationDataLayer
    {

        private readonly string _connectionString;
        public StationDataLayer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<RegionResponseModel> GetRegions()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Regions";

                return con.Query<RegionResponseModel>(query);
            }
        }

        public bool AddNewRegion(string name)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "INSERT INTO Regions(Name) VALUES(@Name)";

                var parameters = new
                {
                    Name = name                    
                };

                var insertedRegions = con.Execute(query, parameters);

                return insertedRegions == 1;
            }
        }

        public IEnumerable<CityResponseModel> GetCities()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Cities";

                return con.Query<CityResponseModel>(query);
            }
        }

        public IEnumerable<CityResponseModel> GetCitiesByRegionId(int regionId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Cities WHERE RegionId=@RegionId";

                var parameters = new
                {
                    RegionId = regionId
                };

                return con.Query<CityResponseModel>(query, parameters);
            }
        }

        public bool AddNewCity(NewCityRequestModel request)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "INSERT INTO Cities(Name, RegionId) VALUES(@Name, @RegionId)";

                var parameters = new
                {
                    Name = request.Name,
                    RegionId = request.RegionId
                };

                var insertedCities = con.Execute(query, parameters);

                return insertedCities == 1;
            }
        }

        public IEnumerable<StationsResponseMoedl> GetStations()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Stations";

                return con.Query<StationsResponseMoedl>(query);
            }
        }

        public IEnumerable<StationsResponseMoedl> GetStationsByCityId(int cityId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Stations WHERE CityId=@CityId";

                var parameters = new
                {
                    CityId = cityId
                };

                return con.Query<StationsResponseMoedl>(query, parameters);
            }
        }

        public bool AddNewStation(NewStationRequestModel request)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "INSERT INTO Stations(Name, CityId) VALUES(@Name, @CityId)";

                var parameters = new
                {
                    Name = request.Name,
                    CityId = request.CityId
                };

                var insertedStations = con.Execute(query, parameters);

                return insertedStations == 1;
            }
        }
    }
}