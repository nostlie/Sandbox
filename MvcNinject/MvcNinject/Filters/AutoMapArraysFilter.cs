using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcNinject.Mappers;
using MvcNinject.Controllers;

namespace MvcNinject.Filters
{
    public class AutoMapArraysFilter : BaseActionFilter
    {
        private Type _sourceType;
        private Type _destType;

        public AutoMapArraysFilter(Type sourceType, Type destType)
        {
            _sourceType = sourceType;
            _destType = destType;
        }

        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            var controller = (IModelMapperController)filterContext.Controller;
            var model = filterContext.Controller.ViewData.Model;
            object viewModel = controller.ModelMapper.Map(model, _sourceType, _destType);
            filterContext.Controller.ViewData.Model = viewModel;
        }
    }
}