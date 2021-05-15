namespace WeatherSpot.DataLayer
{
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using WeatherSpot.Models.ResponseModels;
    using Dapper;
    using System.Data.SqlClient;
    using WeatherSpot.Models.RequestModels;

    public class UserDataLayer
    {

        private readonly string _connectionString;
        public UserDataLayer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<RoleResponseModel> GetRoles()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    $"SELECT * FROM UserRoles";

                return con.Query<RoleResponseModel>(query);
            }
        }

        public IEnumerable<UserResponseModel> GetUsers()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    $"SELECT * FROM Users";

                return con.Query<UserResponseModel>(query);
            }
        }

        public bool CreateUser(NewUserRequestModel requestModel)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "INSERT INTO Users(Username, PasswordHash, Name, RoleId) VALUES(@Username, @Password, @Name, @RoleId)";

                var parameters = new
                {
                    Username = requestModel.Username,
                    Password = requestModel.Password,
                    Name = requestModel.Name,
                    RoleId = requestModel.RoleId
                };

                var insertedRoles = con.Execute(query, parameters);

                return insertedRoles == 1;
            }
        }

        public bool ChangePassword(string newPassword, int userId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "UPDATE Users SET PasswordHash = @Password WHERE Id = @UserId";

                var parameters = new
                {
                    Password = newPassword,
                    UserId = userId
                };

                var affectedRows = con.Execute(query, parameters);

                return affectedRows == 1;
            }
        }

        public bool ChangeUserRole(ChangeUserRoleRequestModel requestModel)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "UPDATE Users SET RoleId = @RoleId WHERE Id = @UserId";

                var parameters = new
                {
                    RoleId = requestModel.RoleId,
                    UserId = requestModel.UserId
                };

                var affectedRows = con.Execute(query, parameters);

                return affectedRows == 1;
            }
        }


        public bool DeactivateUser(int userId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "UPDATE Users SET IsActive = 0 WHERE Id = @UserId";

                var parameters = new
                {
                    UserId = userId
                };

                var affectedRows = con.Execute(query, parameters);

                return affectedRows == 1;
            }
        }

        public IEnumerable<UserResponseModel> GetUser(string username)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    $"SELECT * FROM Users WHERE Username=@Username";

                var parameters = new
                {
                    Username = username
                };

                return con.Query<UserResponseModel>(query, parameters);
            }
        }
    }
}