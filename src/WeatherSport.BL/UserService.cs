namespace WeatherSpot.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using WeatherSpot.BL.Extensions;
    using WeatherSpot.DataLayer;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public class UserService : IUserService
    {
        private readonly UserDataLayer _userDaL;

        public UserService(UserDataLayer userDal)
        {
            _userDaL = userDal;
        }

        public UserModel GetUser(UserLoginRequestModel request)
        {
            return _userDaL.GetUser(request.Username, request.Password);
        }
        public UserModel GetUser(string username)
        {
            return _userDaL.GetUser(username);
        }

        public  IEnumerable<StationsResponseMoedl> GetRoles()
        {
            return _userDaL.GetRoles();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _userDaL.GetUsers();
        }

        public ResponseWithMessage CreateUser(NewUserRequestModel newUser)
        {
            try
            {
                var validationResult = ValidateUser(newUser);

                if (!string.IsNullOrEmpty(validationResult))
                {
                    return new ResponseWithMessage(HttpStatusCode.BadRequest, validationResult);
                }

                var isCreated = _userDaL.CreateUser(newUser);

                if (isCreated)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "User was created successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't create user!");
                }
            }
            catch(Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to create user. {ex.Message}");
            }
        }

        public ResponseWithMessage ChangePassword(string newPassword)
        {
            try
            {
                if (!newPassword.IsPasswordValid())
                {
                    return new ResponseWithMessage(HttpStatusCode.BadRequest, "Password is invalid!");
                }

                //TODO: get current userId
                //TODO: hash password
                var isUpdated = _userDaL.ChangePassword(newPassword, 1);

                if (isUpdated)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "User password was was updated successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't update user password!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to update user password. {ex.Message}");
            }
        }

        public ResponseWithMessage ChangeUserRole(ChangeUserRoleRequestModel requestModel)
        {
            try
            {
                var isUpdated = _userDaL.ChangeUserRole(requestModel);

                if (isUpdated)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "User role was was updated successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't update user role!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to update user role. {ex.Message}");
            }         
        }

        public ResponseWithMessage DeactivateUser(int userId)
        {
            try
            {
                var isDeactivated = _userDaL.DeactivateUser(userId);

                if (isDeactivated)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "User was deactivated successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't deactivat user!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to deactivate user. {ex.Message}");
            }
        }

        private string ValidateUser(NewUserRequestModel user)
        {
            var list = new List<string>();

            if(!user.Username.IsUsernameValid())
            {
                list.Add("Username is invald.");
            }

            if(_userDaL.GetUser(user.Username) != null)
            {
                list.Add("User with that username already exists.");
            }            

            if(!user.Password.IsPasswordValid())
            {
                list.Add("Password is invalid.");
            }

            if(!user.Name.IsNameValid())
            {
                list.Add("Name is invalid.");
            }

            return string.Join(",", list);
        }
    }
}
