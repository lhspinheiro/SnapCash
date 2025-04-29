namespace SnapCash.Communication.Request;

public class RegisterRequest
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public decimal Saldo { get; set; }

    public RegisterRequest(string nomeCompleto, string cpf, string email, string senha, decimal saldo = 0)
    {
        NomeCompleto = nomeCompleto;
        CPF = cpf;
        Email = email;
        Senha = senha;
        Saldo = saldo;       
    }
    public void debitar(decimal valor)
    {
        Saldo -= valor;
    }
    public void creditar(decimal valor)
    {
        Saldo += valor;   
    }
}