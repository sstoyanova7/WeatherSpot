namespace WeatherSpot.BL
{
    using System.Collections.Generic;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public interface IUserService
    {
        public List<RoleResponseModel> GetRoles();
        public List<UserResponseModel> GetAllUsers();
        public List<UserResponseModel> GetActiveUsers();
        //TODO: return response msg
        public bool CreateUser(NewUserRequestModel newUser);
        //TODO: return response msg
        public bool ChangePassword(string newPassword);
        //TODO: return response msg
        public bool ChangeUserRole(ChangeUserRoleRequestModel requestModel);
        //TODO: return response msg
        public bool DeactivateUser(int userId);
    }
}
