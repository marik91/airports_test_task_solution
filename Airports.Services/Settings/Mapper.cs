using Airports.Domain.Entities;
using Airports.Domain.ValueObjects;
using Airports.Services.Models;
using AutoMapper;

namespace Airports.Services.Settings
{
    internal static class Mapper
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<AirportFeedItem, Airport>().ForMember(
                                dest => dest.Coordinates,
                                opt => opt.MapFrom(
                                    src => new Coordinates { Latitude = src.Latitude, Longitude = src.Longitude }))
                            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => CountryMap.GetCountry(src.CountryIsoCode)));
                    });

            return config.CreateMapper();
        }
    }
}