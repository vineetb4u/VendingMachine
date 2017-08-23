using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace VendingMachine.Api.Common.Validation
{
   
    public class CheckModelForNullAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowNullArgumentAttribute>().Any())
            {
                return;
            }



            if (actionContext.ActionArguments.Any(v => v.Value == null))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, "The argument cannot be null");
            }
        }
        
    }
}