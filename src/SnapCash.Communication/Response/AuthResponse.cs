namespace SnapCash.Communication.Response;

public class AuthResponse
{
    public string status { get; set; } = string.Empty;
    
    public DataResponse data { get; set; }
    
    public class DataResponse
    {
        public bool authorization { get; set; } 
    } 
}