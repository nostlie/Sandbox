using System;
using MvcNinjectCars.Controllers;

namespace MvcNinjectCars.Filters
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

        /*
         * After a Controller action is executed, take the resulting Data Access Model and map it to the 
         * ViewModel designated in the action method's Attribute
         */
        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            var controller = (IModelMapperController)filterContext.Controller;
            var model = filterContext.Controller.ViewData.Model;
            object viewModel = controller.ModelMapper.Map(model, _sourceType, _destType);
            filterContext.Controller.ViewData.Model = viewModel;
        }

    }
}
