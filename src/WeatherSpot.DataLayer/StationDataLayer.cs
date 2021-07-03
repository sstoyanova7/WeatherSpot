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

        public IEnumerable<RegionModel> GetRegion(int regionId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                  "SELECT * FROM Regions WHERE Id=@Id";

                var parameters = new
                {
                    Id = regionId
                };

                return con.Query<RegionModel>(query, parameters);
            }
        }

        public IEnumerable<RegionModel> GetRegions()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Regions";

                return con.Query<RegionModel>(query);
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

        public bool DeleteRegion(int regionId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    @"DELETE FROM Stations WHERE CityId IN (SELECT Id FROM Cities WHERE RegionId = @RegionId)
DELETE FROM Cities WHERE RegionId = @RegionId
DELETE FROM Regions WHERE Id = @RegionId";

                var parameters = new
                {
                    RegionId = regionId
                };

                var deletedRegions = con.Execute(query, parameters);

                return deletedRegions >= 1;
            }
        }
        public IEnumerable<CityModel> GetCity(int cityId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                  "SELECT * FROM Cities WHERE Id=@Id";

                var parameters = new
                {
                    Id = cityId
                };

                return con.Query<CityModel>(query, parameters);
            }
        }

        public IEnumerable<CityModel> GetCities()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Cities";

                return con.Query<CityModel>(query);
            }
        }

        public IEnumerable<CityModel> GetCitiesByRegionId(int regionId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Cities WHERE RegionId=@RegionId";

                var parameters = new
                {
                    RegionId = regionId
                };

                return con.Query<CityModel>(query, parameters);
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
        public bool DeleteCity(int cityId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    @"DELETE FROM Stations WHERE CityId=@CityId
DELETE FROM Cities WHERE Id = @CityId";

                var parameters = new
                {
                    CityId = cityId
                };

                var deletedCities = con.Execute(query, parameters);

                return deletedCities >= 1;
            }
        }

        public IEnumerable<StationsResponseMoedl> GetStation(int stationId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "DELETE FROM Stations WHERE Id=@StationId";

                var parameters = new
                {
                    StationId = stationId
                };

                return con.Query<StationsResponseMoedl>(query, parameters);
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

        public IEnumerable<StationsResponseMoedl> GetStationsByRegionId(int regionId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    @"SELECT Stations.Id as Id, Stations.Name as Name FROM Stations
INNER JOIN Cities ON Stations.CityId = Cities.Id
WHERE Cities.RegionId=@RegionId";

                var parameters = new
                {
                    RegionId = regionId
                };

                return con.Query<StationsResponseMoedl>(query, parameters);
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

        public bool DeleteStation(int stationId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "DELETE FROM Stations WHERE Id=@Id";

                var parameters = new
                {
                    Id = stationId
                };

                var deletedStations = con.Execute(query, parameters);

                return deletedStations == 1;
            }
        }
    }
}