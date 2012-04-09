using MvcNinjectCars.Mappers;

namespace MvcNinjectCars.Controllers
{
    public interface IModelMapperController
    {
        IMapper ModelMapper { get; }
    }
}
