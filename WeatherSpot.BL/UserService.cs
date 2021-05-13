namespace WeatherSpot.BL
{
    using System;
    using System.Collections.Generic;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public class UserService : IUserService
    {
        public List<RoleResponseModel> GetRoles()
        {
            throw new NotImplementedException();
        }

        public List<UserResponseModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public List<UserResponseModel> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool ChangeUserRole(ChangeUserRoleRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public bool CreateUser(NewUserRequestModel newUser)
        {
            throw new NotImplementedException();
        }

        public bool DeactivateUser(int userId)
        {
            throw new NotImplementedException();
        }


    }
}
