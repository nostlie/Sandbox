using System;
using MvcNinject.Controllers;

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
            var controller = (IModelMapperController)filterContext.Controller;
            var model = filterContext.Controller.ViewData.Model;
            object viewModel = controller.ModelMapper.Map(model, _sourceType, _destType);
            filterContext.Controller.ViewData.Model = viewModel;
        }

    }
}
