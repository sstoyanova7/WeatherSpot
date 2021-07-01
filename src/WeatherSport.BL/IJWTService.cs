using WeatherSpot.Models.RequestModels;
using WeatherSpot.Models.ResponseModels;

namespace WeatherSpot.BL
{

    public interface IJWTService
    {      
        string GenerateJSONWebToken(UserLoginRequestModel userInfo, out UserModel user);
        UserModel DecodeJWTAsync(string jwt);
    }
}
