using SnapCash.Communication.Enums;

namespace SnapCash.Communication.Request;

public class RegisterRequest
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public UserType UserType { get; set; } 
    public decimal Saldo { get; set; }
    
}