using System.Web.Mvc;
using MvcNinjectCars.Mappers;

namespace MvcNinjectCars.Controllers
{
    public class BaseController<TService> : Controller, IModelMapperController
    {
        protected BaseController(TService service, IMapper mapper)
        {
            Service = service;
            ModelMapper = mapper;
        }

        public TService Service { get; private set; }
        public IMapper ModelMapper { get; private set; }
    }
}