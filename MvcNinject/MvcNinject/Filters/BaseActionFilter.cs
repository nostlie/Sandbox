using System.Web.Mvc;

namespace MvcNinject.Filters
{
    public abstract class BaseActionFilter : IActionFilter, IResultFilter
    {
        public virtual void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public virtual void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }

        public virtual void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
