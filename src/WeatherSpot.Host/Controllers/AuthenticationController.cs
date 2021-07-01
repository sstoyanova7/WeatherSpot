namespace WeatherSpot.Host.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net;
    using WeatherSpot.BL;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    [ApiController]
    [Route("api/[controller]/")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJWTService _jWTService;
        private readonly IUserService _userService;

        public AuthenticationController(IJWTService service, IUserService userService)
        {
            _jWTService = service;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("sign-in")]
        public IActionResult Login([FromBody] UserLoginRequestModel login)
        {
            try
            {
                string jwt = _jWTService.GenerateJSONWebToken(login, out var user);

                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddMinutes(120);

                Response.Cookies.Append("Auth-Tst", jwt);

                return Ok(user);
            }
            catch (AccessViolationException e)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return Content(e.Message);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Content(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            string cookie = Request.Cookies["Auth-Tst"];
            if (cookie != null)
            {
                Response.Cookies.Delete("Auth-Tst");
            }
            IActionResult response = Ok();
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("sign-up")]
        public ResponseWithMessage CreateUser([FromBody] NewUserRequestModel user)
        {
            return _userService.CreateUser(user);
        }
    }
}
