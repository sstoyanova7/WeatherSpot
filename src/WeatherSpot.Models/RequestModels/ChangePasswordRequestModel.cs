namespace WeatherSpot.Models.RequestModels
{
    public class ChangePasswordRequestModel
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}

