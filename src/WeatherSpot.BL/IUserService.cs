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
        public ResponseWithMessage ChangePassword(ChangePasswordRequestModel request);
        public ResponseWithMessage ChangeUserRole(ChangeUserRoleRequestModel request);
        public ResponseWithMessage ChangeUsername(ChangeUsernameRequestModel request);
        public ResponseWithMessage DeactivateUser(int userId);
        public ResponseWithMessage ActivateUser(int userId);
    }
}
