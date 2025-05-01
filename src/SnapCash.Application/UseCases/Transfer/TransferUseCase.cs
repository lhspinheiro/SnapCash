using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SnapCash.Communication.Request;
using SnapCash.Communication.Response;
using SnapCash.Communication.Services;
using SnapCash.Domain.Enums;
using SnapCash.Exception;
using SnapCash.Infrastructure.Data;


namespace SnapCash.Application.UseCases.Transfer;

public class TransferUseCase : ITransferUseCase
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    
    public TransferUseCase(AppDbContext appDbContext, IMapper mapper, IAuthorizationService authorizationService)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
        _authorizationService = authorizationService;
    }
    public async Task <TransferResponseListJson> Execute(TransferRequest request)
    {
        await using var transaction = await _appDbContext.Database.BeginTransactionAsync();
        
        try
        {
            var pagador = await _appDbContext.Registers.FirstOrDefaultAsync(payer => payer.id == request.payerId);
            var recebedor = await _appDbContext.Registers.FirstOrDefaultAsync(payee => payee.id == request.payeeId);

            if (pagador == null || recebedor == null)
            {
                throw new ErrorOnValidationException(new List<string> {"Usuário não encontrado"});
            }
            
            await Validate(request, pagador, recebedor);
       
            pagador.debitar(request.valor);
            recebedor.creditar(request.valor);
       
            var entity = _mapper.Map<Domain.Entities.Transfer>(request);
            entity.payer = pagador;
            entity.payee = recebedor;
       
            await _appDbContext.Transfers.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            
            await transaction.CommitAsync();

            return new TransferResponseListJson
            {
                Pagador = new List<TransferResponse>
                {
                    new TransferResponse
                    {
                        nomeCompleto = pagador.NomeCompleto,
                        saldo = pagador.Saldo,
                        payeeId = pagador.id,
                        payerId = recebedor.id,
                    }
                }, 
                Recebedor = new List<TransferResponse>
                {
                    new TransferResponse
                    {
                        nomeCompleto = recebedor.NomeCompleto,
                        saldo = recebedor.Saldo,
                        payeeId = recebedor.id,
                        payerId = pagador.id,
                    }
                }
            };
        }
        catch 
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    private async Task Validate(TransferRequest request, Domain.Entities.Register pagador, Domain.Entities.Register recebedor)
    {
        if (pagador.UserType == UserType.Lojista)
        {
            throw new ErrorOnValidationException(new List<string> { "Lojistas não podem transferir dinheiro" });
        }
       
        if (pagador.Saldo < request.valor)
        {
            throw new ErrorOnValidationException(new List<string> { "Saldo Insuficiente" });
        }
       
        var auth = await _authorizationService.Authorize();

        if (!auth)
        { 
            throw new ErrorOnValidationException(new List<string> { "Não autorizado" });
        }
        
        if (pagador == null || recebedor == null)
        {
            throw new ErrorOnValidationException(new List<string> {"Usuário não encontrado"});
        }

        if (request.payerId == request.payeeId)
        {
            throw new ErrorOnValidationException(new List<string>{"Não é possível realizar uma transferência para si mesmo."});
        }
    }
}