using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnapCash.Application.UseCases.Transfer;
using SnapCash.Communication.Request;
using SnapCash.Communication.Response;

namespace SnapCash.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [ProducesResponseType(typeof(TransferResponseListJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Transfer([FromServices] ITransferUseCase useCase, [FromBody] TransferRequest request)
        {
            var response = await useCase.Execute(request);
            
            return Created(string.Empty, response);
        }
    }
}
