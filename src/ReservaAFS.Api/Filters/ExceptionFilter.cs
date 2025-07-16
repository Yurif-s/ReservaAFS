using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Exception;
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
        if (context.Exception is ErrorOnValidationException errorOnValidationException)
        {
            var errorResponse = new ResponseErrorMessageJson(errorOnValidationException.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else if (context.Exception is NotFoundException notFoundException)
        {
            var errorResponse = new ResponseErrorMessageJson(notFoundException.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Result = new NotFoundObjectResult(errorResponse);
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
        var errorResponse = new ResponseErrorMessageJson(ResourceErrorMessages.THROW_UNKNOW_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
