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
        var reserveAfsException = (ReservaAFSException)context.Exception;

        var errorResponse = new ResponseErrorMessageJson(reserveAfsException.GetErrors());

        context.HttpContext.Response.StatusCode = reserveAfsException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }
    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorMessageJson(ResourceErrorMessages.THROW_UNKNOW_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
