using Microsoft.AspNetCore.Mvc;
using ReservaAFS.Application.UseCases.Equipments.Create;
using ReservaAFS.Application.UseCases.Equipments.GetAll;
using ReservaAFS.Application.UseCases.Equipments.GetById;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EquipmentsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedEquipmentJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromServices] ICreateEquipmentUseCase useCase,
        [FromBody] RequestEquipmentJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseCreatedEquipmentJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllEquipmentsUseCase useCase)
    {
        var response = await useCase.Execute();

        if(response.Equipments.Count == 0)
            return NoContent();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:long}")]
    [ProducesResponseType(typeof(ResponseCreatedEquipmentJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetByIdEquipmentUseCase useCase,
        [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
}
