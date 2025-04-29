using AutoMapper;
using SnapCash.Communication.Request;
using SnapCash.Communication.Response;
using SnapCash.Domain.Entities;

namespace SnapCash.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestMapper();
        ResponseMapper();

    }

    private void RequestMapper()
    {
        CreateMap<RegisterRequest, Domain.Entities.Register>();
        CreateMap<TransferRequest, Transfer>();
    }
    private void ResponseMapper()
    {
        CreateMap<Domain.Entities.Register, RegisterResponse>();
    }
}