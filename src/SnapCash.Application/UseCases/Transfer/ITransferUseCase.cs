using SnapCash.Communication.Request;
using SnapCash.Communication.Response;

namespace SnapCash.Application.UseCases.Transfer;

public interface ITransferUseCase
{
    public Task <TransferResponseListJson> Execute(TransferRequest request);
}  