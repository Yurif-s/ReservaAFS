using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ReservaAFSException)
            HandleProjectException(context);
        else
            ThrowUnknowError(context);
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException)
        {
            var exception = (ErrorOnValidationException)context.Exception;
            var errorResponse = new ResponseErrorMessageJson(exception.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseErrorMessageJson(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorMessageJson("Erro desconhecido.");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
