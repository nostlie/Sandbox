using System;
using System.Web.Mvc;
using MvcNinjectCars.Filters;

namespace MvcNinjectCars.Attributes
{
    /*
     * This is a basic implementation of the ActionFilterAttribute abstract class. 
     *      All this does is hold the SourceType and DestType properties and pass them
     *      to the AutoMapFilter when OnActionExecuted is called.
     */
    public class AutoMapAttribute : ActionFilterAttribute
    {
        private readonly Type _sourceType;
        private readonly Type _destType;

        public AutoMapAttribute(Type sourceType, Type destType)
        {
            _sourceType = sourceType;
            _destType = destType;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var filter = new AutoMapFilter(SourceType, DestType);
            filter.OnActionExecuted(filterContext);
        }

        public Type SourceType
        {
            get { return _sourceType; }
        }

        public Type DestType
        {
            get { return _destType; }
        }

    }
}