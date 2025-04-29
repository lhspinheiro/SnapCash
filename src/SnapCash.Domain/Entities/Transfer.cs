namespace SnapCash.Domain.Entities;

public class Transfer
{
    public Guid id { get; set; } = Guid.NewGuid();
    public decimal valor { get; set; } 
    public int payerId { get; set; }
    public Register payer { get; set; }
    
    public int payeeId { get; set; }
    public Register payee { get; set; }
}