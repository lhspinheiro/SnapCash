namespace SnapCash.Communication.Request;

public class TransferRequest
{
    public decimal valor { get; set; } 
    
    public int payerId { get; set; }
    
    public int payeeId { get; set; }
}