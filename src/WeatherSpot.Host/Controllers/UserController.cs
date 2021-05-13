namespace WeatherSpot.Host.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using WeatherSpot.BL;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/getRoles")]
        public List<RoleResponseModel> GetRoles()
        {
            return _userService.GetRoles();
        }

        [HttpGet]
        [Route("api/getUsers")]
        public List<UserResponseModel> GetUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        [Route("api/getActiveUsers")]
        public List<UserResponseModel> GetActiveUsers()
        {
            return _userService.GetActiveUsers();
        }


        [HttpPost]
        [Route("api/createNewUser")]
        public bool CreateNewUser([FromBody] NewUserRequestModel request)
        {
            return _userService.CreateUser(request);
        }

        [HttpPut]
        [Route("api/changePassword")]
        //TODO: return response msg
        public bool ChangePassword([FromBody] string password)
        {
            return _userService.ChangePassword(password);
        }

        [HttpPut]
        [Route("api/changeUserRole")]
        //TODO: return response msg
        public bool ChangeUserRole([FromBody] ChangeUserRoleRequestModel request)
        {
            return _userService.ChangeUserRole(request);
        }

        [HttpPut]
        [Route("api/deactivateUser")]
        //TODO: return response msg
        public bool DeactivateUser([FromBody] int userId)
        {
            return _userService.DeactivateUser(userId);
        }



    }
}
