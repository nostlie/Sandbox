using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNinject.Mappers;

namespace MvcNinject.Controllers
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