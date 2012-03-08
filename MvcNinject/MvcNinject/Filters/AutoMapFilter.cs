using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace MvcNinject.Filters
{
    public class AutoMapFilter : BaseActionFilter
    {
        private Type _sourceType;
        private Type _destType;

        public AutoMapFilter(Type SourceType, Type DestType)
        {
            _sourceType = SourceType;
            _destType = DestType;
        }

        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model;
            Mapper.CreateMap(_sourceType, _destType);
            object viewModel = Mapper.Map(model, _sourceType, _destType);
            filterContext.Controller.ViewData.Model = viewModel;
        }

    }
}
