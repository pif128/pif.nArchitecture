using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pif.Core.Application.Requests;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Models;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology;

namespace pif.Kodlama.io.Devs.WepAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TechnologiessController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand technologyCommand)
		{
			CreatedTechnologyDto createdTechnologyDto = await Mediator.Send(technologyCommand);
			return Created("", createdTechnologyDto);
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
		{
			UpdatedTechnologyDto updatedTechnologyDto = await Mediator.Send(updateTechnologyCommand);
			return Created("", updatedTechnologyDto);
		}
		[HttpDelete("Id")]
		public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
		{
			DeletedTechnologyDto deletedTechnologyDto = await Mediator.Send(deleteTechnologyCommand);
			return Ok(deletedTechnologyDto);
		}
		[HttpGet]
		public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
		{
			GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
			ListTechnologyModel technologyListModel = await Mediator.Send(getListTechnologyQuery);
			return Ok(technologyListModel);
		}
		[HttpGet("Id")]
		public async Task<IActionResult> GetById([FromQuery] GetByIdTechnologyQuery getByIdTechnologyQuery)
		{
			GetByIdTechnologyDto technologyGetByIdDto = await Mediator.Send(getByIdTechnologyQuery);
			return Ok(technologyGetByIdDto);
		}
	}
}
