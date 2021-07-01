namespace WeatherSpot.BL
{
    using System.Collections.Generic;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public interface IUserService
    {
        public UserModel GetUser(UserLoginRequestModel request);
        public UserModel GetUser(string username);
        public IEnumerable<StationsResponseMoedl> GetRoles();
        public IEnumerable<UserModel> GetUsers();
        public ResponseWithMessage CreateUser(NewUserRequestModel newUser);
        public ResponseWithMessage ChangePassword(string newPassword);
        public ResponseWithMessage ChangeUserRole(ChangeUserRoleRequestModel requestModel);
        public ResponseWithMessage DeactivateUser(int userId);
    }
}
