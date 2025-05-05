using System.Net.Http.Json;
using System.Text.Json;
using SnapCash.Communication.Response;

namespace SnapCash.Communication.Services.Notify;

public class SendNotification : ISendNotification
{
    private readonly HttpClient _httpClient;

    public SendNotification(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private const string URL = "https://util.devi.tools/api/v2/notify";

    public async Task<NotificationResponse> Send()
    {
        try
        {
            var notification = await _httpClient.PostAsJsonAsync(URL, string.Empty);
            if (notification.IsSuccessStatusCode)
            {
                Console.WriteLine("----- Notificação enviada com sucesso -----");
                return new NotificationResponse
                {
                    status = "sucess",
                    message = "notificação enviada com sucesso"
                };
            }
            
            Console.WriteLine("----- Erro ao enviar notificação -----");
            return new NotificationResponse
            {
                status = "erro",
                message = "erro inesperado"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao conectar com o serviço da API");
            return new NotificationResponse
            {
                status = "erro",
                message = $"erro ao conectar com serviço da API {e.Message}"
            };
        }
    }
}