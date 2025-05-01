namespace SnapCash.Communication.Response;

public class TransferResponseListJson
{
    public List<TransferResponse> Pagador { get; set; } = [];
    public List<TransferResponse> Recebedor { get; set; } = [];
    
}