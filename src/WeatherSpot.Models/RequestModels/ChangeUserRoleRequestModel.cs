namespace WeatherSpot.Models.RequestModels
{
    public class ChangeUserRoleRequestModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
