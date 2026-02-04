using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UserManagement.API.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new
            {
                message = context.Exception.Message
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }
    }
}
