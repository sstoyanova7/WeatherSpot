using System;

namespace WeatherSpot.Models.ResponseModels
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public DateTime UserCreatedOn { get; set; }
        public int RoleId { get; set; }
        public DateTime RoleLastChanhgedOn { get; set; }
    }
}
