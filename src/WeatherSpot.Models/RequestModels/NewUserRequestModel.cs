namespace WeatherSpot.Models.RequestModels
{

    public class NewUserRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
    }
}
