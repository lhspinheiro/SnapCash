namespace SnapCash.Communication.Response;

public class RegisterResponse
{
    public int id { get; set; }
    public string nomeCompleto { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public decimal saldo { get; set; } 
}