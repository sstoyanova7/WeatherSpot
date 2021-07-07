using AutoMapper;
using WeatherSpot.Models.DbResponseModels;
using WeatherSpot.Models.ResponseModels;

namespace WeatherSpot.Models.RequestModels.AutoMapper
{
    public class StationDataDbModelStationDataMappingProfile : Profile
    {
        public StationDataDbModelStationDataMappingProfile()
        {
            CreateMap<StationDataDbModel, StationData>()
                .ForMember(dest => dest.StationDataId, act => act.MapFrom(src => src.StationDataId))
                .ForMember(dest => dest.StationId, act => act.MapFrom(src => src.StationId))
                .ForMember(dest => dest.CityId, act => act.MapFrom(src => src.CityId))
                .ForMember(dest => dest.RegionId, act => act.MapFrom(src => src.RegionId))
                .ForMember(dest => dest.Month, act => act.MapFrom(src => src.Month))
                .ForMember(dest => dest.Year, act => act.MapFrom(src => src.Year))               
                .ForMember(dest => dest.Weight, act => act.MapFrom(src => src.Weight))
                .ForMember(dest => dest.TemperatureData, act => act.MapFrom(src => new TemperatureData
                {
                    Average = src.AverageTemperature,
                    Delta = src.DeltaTemperature,
                    Max = src.MaxTemperature,
                    Min = src.MinTemperature,
                    DayMax = src.DayMaxTemperature,
                    DayMin = src.DayMinTemperature
                }))
                .ForMember(dest => dest.RainData, act => act.MapFrom(src => new RainData
                {
                    Total = src.TotalRain,
                    QQn = src.QQNRain,
                    Max = src.MaxRain,
                    DayMax = src.DayMaxRain
                }))
                .ForMember(dest => dest.StatisticsData, act => act.MapFrom(src => new StatisticsData
                {
                    DaysRainOver1mm = src.DaysRainOver1mm,
                    DaysRainOver10mm = src.DaysRainOver1mm,
                    DaysWindOver14ms = src.DaysWindOver14ms,
                    DaysThunderbolts = src.DaysThunderbolts
                }));
        }
    }
}