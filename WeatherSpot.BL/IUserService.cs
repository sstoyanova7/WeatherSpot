namespace WeatherSpot.BL
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public interface IUserService
    {
        public IEnumerable<RoleResponseModel> GetRoles();
        public IEnumerable<UserResponseModel> GetUsers();
        //TODO: return response msg
        public ResponseWithMessage CreateUser(NewUserRequestModel newUser);
        //TODO: return response msg
        public ResponseWithMessage ChangePassword(string newPassword);
        //TODO: return response msg
        public ResponseWithMessage ChangeUserRole(ChangeUserRoleRequestModel requestModel);
        //TODO: return response msg
        public ResponseWithMessage DeactivateUser(int userId);
    }
}
