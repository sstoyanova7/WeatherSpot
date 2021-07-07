namespace WeatherSpot.Models.DbResponseModels
{
    public class StationDataDbModel
    {
        public int StationDataId { get; set; }
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double Weight { get; set; }
        public double AverageTemperature { get; set; }
        public double DeltaTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public int DayMinTemperature { get; set; }
        public int DayMaxTemperature { get; set; }
        public int TotalRain { get; set; }
        public int QQNRain { get; set; }
        public int MaxRain { get; set; }
        public int DayMaxRain { get; set; }
        public int DaysRainOver1mm { get; set; }
        public int DaysRainOver10mm { get; set; }
        public int DaysWindOver14ms { get; set; }   
        public int DaysThunderbolts { get; set; }           
    }
}
