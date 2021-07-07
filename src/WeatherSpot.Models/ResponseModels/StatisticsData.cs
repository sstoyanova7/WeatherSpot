namespace WeatherSpot.Models.ResponseModels
{
    public class StatisticsData
    {
        public int DaysRainOver1mm { get; set; }
        public int DaysRainUnder1mm { get; set; }
        public int DaysWindOver14ms { get; set; }
        public int DaysThunderbolts { get; set; }
    }
}
