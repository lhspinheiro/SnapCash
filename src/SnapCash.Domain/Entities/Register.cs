namespace SnapCash.Domain.Entities;

public class Register
{
    public int id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public decimal Saldo { get; set; }


    
    public void debitar(decimal valor)
    {
        Saldo -= valor;
    }
    public void creditar(decimal valor)
    {
        Saldo += valor;   
    }
}