using Microsoft.AspNetCore.Mvc;
using ReservaAFS.Application.UseCases.Reserves.Create;
using ReservaAFS.Application.UseCases.Reserves.Delete;
using ReservaAFS.Application.UseCases.Reserves.GetAll;
using ReservaAFS.Application.UseCases.Reserves.GetById;
using ReservaAFS.Application.UseCases.Reserves.Update;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReservesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedReserveJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromServices] ICreateReserveUseCase useCase,
        [FromBody] RequestReserveJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseReservesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllReservesUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Reserves.Count != 0)
            return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id:long}")]
    [ProducesResponseType(typeof(ResponseReserveJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetReserveByIdUseCase useCase, 
        [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteReserveUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateReserveUseCase useCase,
        [FromBody] RequestReserveJson request,
        [FromRoute] long id)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
