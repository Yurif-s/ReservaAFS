using Microsoft.AspNetCore.Mvc;
using ReservaAFS.Application.UseCases.Reserves.Create;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReservesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortReserveJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromServices] ICreateReserveUseCase useCase,
        [FromBody] RequestCreateReserveJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
