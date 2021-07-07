namespace WeatherSpot.Models.ResponseModels
{
    public class TemperatureData
    {
        public double Average { get; set; }
        public double Delta { get; set; }
        public double Max{ get; set; }
        public double Min { get; set; }
        public int DayMax { get; set; }
        public int DayMin{ get; set; }
    }
}
