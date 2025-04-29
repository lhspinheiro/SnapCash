using Microsoft.AspNetCore.Mvc;
using SnapCash.Application.UseCases.Register;
using SnapCash.Communication.Request;
using SnapCash.Communication.Response;

namespace SnapCash.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IRegisterUser useCase, [FromBody] RegisterRequest request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
        
        
    }
}
