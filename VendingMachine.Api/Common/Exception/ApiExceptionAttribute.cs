using System.Net.Http;
using System.Web.Http.Filters;

namespace VendingMachine.Api.Common
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;
            actionExecutedContext.ActionContext.Response = actionExecutedContext.ActionContext.Request.CreateResponse(exception.Message);

            base.OnException(actionExecutedContext);
        }
    }
}