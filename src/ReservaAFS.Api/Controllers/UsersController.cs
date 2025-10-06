using Microsoft.AspNetCore.Mvc;
using ReservaAFS.Application.UseCases.Reserves.Delete;
using ReservaAFS.Application.UseCases.Reserves.Update;
using ReservaAFS.Application.UseCases.Users.Create;
using ReservaAFS.Application.UseCases.Users.Delete;
using ReservaAFS.Application.UseCases.Users.GetAll;
using ReservaAFS.Application.UseCases.Users.GetById;
using ReservaAFS.Application.UseCases.Users.Update;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromServices] ICreateUserUseCase useCase,
        [FromBody] RequestUserJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseUsersJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllUsersUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Users.Count != 0)
            return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id:long}")]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetByIdUserUseCase useCase,
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
        [FromServices] IDeleteUserUseCase useCase,
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
        [FromServices] IUpdateUserUseCase useCase,
        [FromBody] RequestUserJson request,
        [FromRoute] long id)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
