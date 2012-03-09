using System;
using AutoMapper;
using MvcNinject.Models;
using MvcNinject.Models.Views;

namespace MvcNinject.Mappers
{
    public class BlahMapper : IMapper
    {
        static BlahMapper()
        {
            Mapper.CreateMap<BlahModel, BlahIndexViewModel>();
            Mapper.CreateMap<BlahModel, BlahAboutViewModel>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}