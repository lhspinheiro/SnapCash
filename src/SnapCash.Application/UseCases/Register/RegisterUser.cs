using AutoMapper;
using SnapCash.Application.Security;
using SnapCash.Application.Validations;
using SnapCash.Communication.Request;
using SnapCash.Communication.Response;
using SnapCash.Exception;
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
        await Validate(request);
        
        var encrypt = new BCryptAlgoritm();
        
        var entity = _mapper.Map<Domain.Entities.Register>(request);
        entity.Senha = encrypt.HashPassword(request.Senha);
        
        
        await _appDbContext.Registers.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        
        return _mapper.Map<RegisterResponse>(entity);
    }

    private async Task Validate(RegisterRequest request)
    {
        var validate = new ValidationRegisterRequest();
        
        var result = await validate.ValidateAsync(request);

        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        } 
    }
    
}