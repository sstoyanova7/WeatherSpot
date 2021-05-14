namespace WeatherSpot.Host.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
        public IEnumerable<RoleResponseModel> GetRoles()
        {
            return _userService.GetRoles();
        }

        [HttpGet]
        [Route("api/getUsers")]
        public IEnumerable<UserResponseModel> GetUsers()
        {
            return _userService.GetUsers();
        }

        //TODO: query params? 
        [HttpGet]
        [Route("api/getActiveUsers")]
        public UserResponseModel GetActiveUsers()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        [Route("api/createNewUser")]
        public ResponseWithMessage CreateNewUser([FromBody] NewUserRequestModel request)
        {
            return _userService.CreateUser(request);
        }

        [HttpPut]
        [Route("api/changePassword")]        
        public ResponseWithMessage ChangePassword([FromBody] string password)
        {
            return _userService.ChangePassword(password);
        }

        [HttpPut]
        [Route("api/changeUserRole")]
        public ResponseWithMessage ChangeUserRole([FromBody] ChangeUserRoleRequestModel request)
        {
            return _userService.ChangeUserRole(request);
        }

        [HttpPut]
        [Route("api/deactivateUser")]
        public ResponseWithMessage DeactivateUser([FromBody] int userId)
        {
            return _userService.DeactivateUser(userId);
          
        }
    }
}
