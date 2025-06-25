namespace SnapCash.Communication.Services.Authorization;

public interface IAuthorizationService
{
    public Task <bool> Authorize();
}