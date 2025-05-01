using System.Net;

namespace SnapCash.Exception;

public class ErrorOnValidationException : SnapCashException
{
    private readonly List<string> _errors;


    public ErrorOnValidationException(List<string> errorsMessages)
    {
        _errors = errorsMessages;
    }
    
    public override List<string> ErrorMessages() => _errors;

    public override HttpStatusCode ErrorstatusCode() => HttpStatusCode.BadRequest;
}