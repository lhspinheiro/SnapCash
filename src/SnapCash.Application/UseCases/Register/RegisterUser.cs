using AutoMapper;
using SnapCash.Communication.Request;
using SnapCash.Communication.Response;
using SnapCash.Infrastructure.Data;

namespace SnapCash.Application.UseCases.Register;

public class RegisterUser : IRegisterUser
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public RegisterUser(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }
    public async Task<RegisterResponse> Execute(RegisterRequest request)
    {
        var entity = _mapper.Map<Domain.Entities.Register>(request);
        
        await _appDbContext.Registers.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        
        return _mapper.Map<RegisterResponse>(entity);
    }
}