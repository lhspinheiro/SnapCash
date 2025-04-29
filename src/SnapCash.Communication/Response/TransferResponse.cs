namespace SnapCash.Communication.Response;

public class TransferResponse
{
    public string nomeCompleto { get; set; } = string.Empty;
    
    public decimal saldo { get; set; } 
    
    public int payerId { get; set; }
    
    public int payeeId { get; set; }
}