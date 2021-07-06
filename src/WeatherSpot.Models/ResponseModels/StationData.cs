namespace WeatherSpot.Models.ResponseModels
{
    public class StationData
    {
        public int StationDataId { get; set; }
        public int StationId { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public TemperatureData TemperatureData { get; set; }
        public RainData RainData { get; set; }
        public StatisticsData StatisticsData { get; set; }
    }
}
