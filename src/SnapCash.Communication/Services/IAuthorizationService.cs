namespace SnapCash.Communication.Services;

public interface IAuthorizationService
{
    public Task <bool> Authorize();
}