using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SnapCash.Communication.Request;
using SnapCash.Communication.Response;
using SnapCash.Communication.Services;
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
        
       var pagador = await _appDbContext.Registers.FirstOrDefaultAsync(payer => payer.id == request.payerId);
       var recebedor = await _appDbContext.Registers.FirstOrDefaultAsync(payee => payee.id == request.payeeId);

       if (pagador.Saldo < request.valor)
       {
           throw new Exception("Saldo insuficiente");
       }
       
       var auth = await _authorizationService.Authorize();

       if (!auth)
       {
           throw new Exception("não autorizado");
       }
       
       pagador.debitar(request.valor);
       recebedor.creditar(request.valor);
       
       var entity = _mapper.Map<Domain.Entities.Transfer>(request);
       entity.payer = pagador;
       entity.payee = recebedor;
       
       
       await _appDbContext.Transfers.AddAsync(entity);
       await _appDbContext.SaveChangesAsync();

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
}