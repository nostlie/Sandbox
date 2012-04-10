using MvcNinjectCars.Mappers;

namespace MvcNinjectCars.Controllers
{
    /*
     * This is here so any controller classes that need to use the AutoMapper 
     *      can inherit the IMapper object
     */
    public interface IModelMapperController
    {
        IMapper ModelMapper { get; }
    }
}
