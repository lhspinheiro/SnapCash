using System.Text.Json;
using SnapCash.Communication.Response;

namespace SnapCash.Communication.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly HttpClient _httpClient;


    public AuthorizationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    private const string URL = "https://util.devi.tools/api/v2/authorize";
    
    public async Task<bool> Authorize()
    {
       var content = string.Empty;
       
       var auth = await _httpClient.GetAsync(URL);

       if (!auth.IsSuccessStatusCode)
       {
           return false;
       }
       
       auth.EnsureSuccessStatusCode();
       
       content = await auth.Content.ReadAsStringAsync();
       
       var result =  JsonSerializer.Deserialize<AuthResponse>(content);
       
       return result?.status == "success";

    }
}