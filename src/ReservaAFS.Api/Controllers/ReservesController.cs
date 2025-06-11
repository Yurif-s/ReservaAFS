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
    [ProducesResponseType(typeof(ResponseCreateReserveJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create(
        [FromServices] ICreateReserveUseCase useCase,
        [FromBody] RequestCreateReserveJson request)
    {
        var result = useCase.Execute(request);

        return Created(string.Empty, request);
    }
}
