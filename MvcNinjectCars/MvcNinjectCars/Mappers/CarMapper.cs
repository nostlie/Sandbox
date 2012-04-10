using System;
using AutoMapper;
using MvcNinjectCars.Models;
using MvcNinjectCars.Models.Views;

namespace MvcNinjectCars.Mappers
{
    public class CarMapper : IMapper
    {
        static CarMapper()
        {
            // Configure the AutoMapper for future use
            Mapper.CreateMap<CarModel, CarViewModel>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}