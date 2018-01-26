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
            // Used automapper here, understand that it is kind of automagic with uknown process of mapping attributes
            // but wanted to show this way of mapping instead of doing every property by hand in some extension method for example
            var config = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<AirportFeedItem, Airport>().ForMember(
                                dest => dest.Coordinates,
                                opt => opt.MapFrom(
                                    src => new Coordinates { Latitude = src.Latitude, Longitude = src.Longitude }))
                            .ForMember(
                                dest => dest.Country,
                                opt => opt.MapFrom(src => CountryMap.GetCountry(src.CountryIsoCode)));
                    });

            return config.CreateMapper();
        }
    }
}