namespace SnapCash.Application.Security;

public class BCryptAlgoritm
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
}