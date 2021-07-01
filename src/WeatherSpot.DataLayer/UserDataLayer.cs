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

        public UserModel GetUser(string username)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Users WHERE Username = @Username";

                var parameters = new
                {
                    Username = username
                };

                return con.QueryFirstOrDefault<UserModel>(query, parameters);
            }
        }

        public UserModel GetUser(string username, string password)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @Password";

                var parameters = new
                {
                    Username = username,
                    password = password
                };

                return con.QueryFirstOrDefault<UserModel>(query, parameters);
            }
        }

        public IEnumerable<StationsResponseMoedl> GetRoles()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM UserRoles";

                return con.Query<StationsResponseMoedl>(query);
            }
        }

        public IEnumerable<UserModel> GetUsers()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "SELECT * FROM Users";

                return con.Query<UserModel>(query);
            }
        }

        public bool CreateUser(NewUserRequestModel request)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "INSERT INTO Users(Username, PasswordHash, Email, Name) VALUES(@Username, @Password, @Email, @Name)";

                var parameters = new
                {
                    Username = request.Username,
                    Password = request.Password,
                    Email = request.Email,
                    Name = request.Name,
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

        public bool ChangeUserRole(ChangeUserRoleRequestModel request)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "UPDATE Users SET RoleId = @RoleId WHERE Id = @UserId";

                var parameters = new
                {
                    RoleId = request.RoleId,
                    UserId = request.UserId
                };

                var affectedRows = con.Execute(query, parameters);

                return affectedRows == 1;
            }
        }

        public bool ChangeUsername(ChangeUsernameRequestModel request)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "UPDATE Users SET Username = @Username WHERE Id = @UserId";

                var parameters = new
                {
                    Username = request.Username,
                    UserId = request.UserId
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

        public bool ActivateUser(int userId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    "UPDATE Users SET IsActive = 1 WHERE Id = @UserId";

                var parameters = new
                {
                    UserId = userId
                };

                var affectedRows = con.Execute(query, parameters);

                return affectedRows == 1;
            }
        }
    }
}