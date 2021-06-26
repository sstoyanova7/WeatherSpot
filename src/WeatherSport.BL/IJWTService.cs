using WeatherSpot.Models.RequestModels;
using WeatherSpot.Models.ResponseModels;

namespace WeatherSpot.BL
{

    public interface IJWTService
    {      
        string GenerateJSONWebToken(UserLoginRequestModel userInfo);
        UserModel DecodeJWTAsync(string jwt);
    }
}
