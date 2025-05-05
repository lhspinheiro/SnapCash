using SnapCash.Communication.Response;

namespace SnapCash.Communication.Services.Notify;

public interface ISendNotification
{
    public Task<NotificationResponse> Send(); 
}