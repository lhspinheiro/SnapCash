using System.Net;

namespace SnapCash.Exception;

public abstract class SnapCashException : System.Exception
{
    public abstract List<string> ErrorMessages();
    public abstract HttpStatusCode ErrorstatusCode();
    
}