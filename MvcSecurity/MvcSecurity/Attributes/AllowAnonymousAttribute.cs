using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSecurity.Attributes
{
    // This attribute has no special implementation, just applying to methods and using the LoginAuthorize filter
    // class to check which actions/controllers allow anonymous access
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AllowAnonymousAttribute : Attribute
    {

    }
}