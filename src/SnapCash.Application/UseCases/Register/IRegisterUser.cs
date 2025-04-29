using SnapCash.Communication.Request;
using SnapCash.Communication.Response;

namespace SnapCash.Application.UseCases.Register;

public interface IRegisterUser
{
    public Task<RegisterResponse> Execute(RegisterRequest request);
}