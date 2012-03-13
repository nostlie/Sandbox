using System;
using AutoMapper;
using MvcNinject.Models;
using MvcNinject.Models.Views;

namespace MvcNinject.Mappers
{
    public class BlahMapper : IMapper
    {
        /*
         * Need to add a CreateMap config method for each mapping that will happen in the application
         */
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