namespace WeatherSpot.Models.RequestModels
{
    public class StationDataRequestModel
    {
        public int StationId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public double TemperatureAverage { get; set; }
        public double TemperatureDelta { get; set; }
        public double TemperatureMax { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureDayMax { get; set; }
        public double TemperatureDayMin { get; set; }
        public int RainTotal { get; set; }
        public int RainQQn { get; set; }
        public int RainMax { get; set; }
        public int RainDayMax { get; set; }
        public int DaysRainOver1mm { get; set; }
        public int DaysRainOver10mm { get; set; }
        public int DaysWindOver14ms { get; set; }
        public int DaysThunderbolts { get; set; }
    }
}
