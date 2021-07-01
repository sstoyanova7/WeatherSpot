namespace WeatherSpot.BL
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using WeatherSpot.Models.RequestModels;
    using WeatherSpot.Models.ResponseModels;

    public class JWTService : IJWTService
    {
        private IConfiguration _config;

        private readonly IUserService userService;

        public JWTService(IConfiguration config, IUserService service)
        {
            _config = config;
            userService = service;
        }

        public string GenerateJSONWebToken(UserLoginRequestModel requestModel)
        {
            UserModel user = userService.GetUser(requestModel);
            if (user == null || !user.IsActive)
            {
                throw new AccessViolationException("There is no active user with those credentials");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, requestModel.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel DecodeJWTAsync(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(jwt) as JwtSecurityToken;
            var username = jwtToken.Claims.First(claim => claim.Type == "username").Value;

            return userService.GetUser(username);
        }
    }
}