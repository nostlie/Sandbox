using MvcNinject.Mappers;

namespace MvcNinject.Controllers
{
    public interface IModelMapperController
    {
        IMapper ModelMapper { get; }
    }
}
