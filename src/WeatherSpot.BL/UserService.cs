namespace WeatherSpot.BL
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Helpers;
    using WeatherSpot.BL.Extensions;
    using WeatherSpot.DataLayer;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public class UserService : IUserService
    {
        private readonly UserDataLayer _userDal;

        public UserService(UserDataLayer userDal)
        {
            _userDal = userDal;
        }

        public UserModel GetUser(UserLoginRequestModel request)
        {
            var hashedPassword = Crypto.SHA256(request.Password);
            return _userDal.GetUser(request.Username, hashedPassword);
        }
        public UserModel GetUser(string username)
        {
            return _userDal.GetUser(username);
        }

        public IEnumerable<StationsResponseMoedl> GetRoles()
        {
            return _userDal.GetRoles();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _userDal.GetUsers();
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

                newUser.Password = Crypto.Hash(newUser.Password);

                var isCreated = _userDal.CreateUser(newUser);

                if (isCreated)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "User was created successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't create user!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to create user. {ex.Message}");
            }
        }

        public ResponseWithMessage ChangePassword(ChangePasswordRequestModel request)
        {
            try
            {
                var newPassword = request.NewPassword;
                if (!newPassword.IsPasswordValid())
                {
                    return new ResponseWithMessage(HttpStatusCode.BadRequest, "Password is invalid!");
                }

                var hashedPassword = Crypto.Hash(newPassword);
                var isUpdated = _userDal.ChangePassword(hashedPassword, request.UserId);

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

        public ResponseWithMessage ChangeUserRole(ChangeUserRoleRequestModel request)
        {
            try
            {
                var isUpdated = _userDal.ChangeUserRole(request);

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


        public ResponseWithMessage ChangeUsername(ChangeUsernameRequestModel request)
        {
            try
            {
                var isUpdated = _userDal.ChangeUsername(request);

                if (isUpdated)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "Username was was changed successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't change username!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to change username. {ex.Message}");
            }
        }
        public ResponseWithMessage DeactivateUser(int userId)
        {
            try
            {
                var isDeactivated = _userDal.DeactivateUser(userId);

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

        public ResponseWithMessage ActivateUser(int userId)
        {
            try
            {
                var isDeactivated = _userDal.ActivateUser(userId);

                if (isDeactivated)
                {
                    return new ResponseWithMessage(HttpStatusCode.OK, "User was activated successfully!");
                }
                else
                {
                    return new ResponseWithMessage(HttpStatusCode.InternalServerError, "Couldn't activat user!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseWithMessage(HttpStatusCode.InternalServerError, $"An error occured while trying to activate user. {ex.Message}");
            }
        }

        private string ValidateUser(NewUserRequestModel user)
        {
            var list = new List<string>();

            if (!user.Username.IsUsernameValid())
            {
                list.Add("Username is invald.");
            }

            if (_userDal.GetUser(user.Username) != null)
            {
                list.Add("User with that username already exists.");
            }

            if (!user.Password.IsPasswordValid())
            {
                list.Add("Password is invalid.");
            }

            if (!user.Name.IsNameValid())
            {
                list.Add("Name is invalid.");
            }

            return string.Join(",", list);
        }
    }
}
