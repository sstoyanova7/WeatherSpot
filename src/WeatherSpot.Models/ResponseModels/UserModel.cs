namespace WeatherSpot.Models.ResponseModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
