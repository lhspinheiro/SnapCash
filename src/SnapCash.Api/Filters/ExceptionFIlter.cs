using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SnapCash.Communication.Response;
using SnapCash.Exception;

namespace SnapCash.Api.Filters;

public class ExceptionFIlter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is SnapCashException snapCashException)
        {
            context.HttpContext.Response.StatusCode = (int)snapCashException.ErrorstatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessages
            {
                ErrorMessages = snapCashException.ErrorMessages()
            });
        }
    }
}