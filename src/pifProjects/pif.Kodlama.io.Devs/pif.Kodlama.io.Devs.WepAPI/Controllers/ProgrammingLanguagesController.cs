using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pif.Core.Application.Requests;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

namespace pif.Kodlama.io.Devs.WepAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProgrammingLanguagesController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createBrandCommand)
		{
			CreatedProgrammingLanguageDto result = await Mediator.Send(createBrandCommand);
			return Created("", result);
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
		{
			UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
			return Created("", result);
		}

		[HttpGet]
		public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
		{
			GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
			ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
			return Ok(result);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
		{
			GetByIdProgrammingLanguageDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
			return Ok(programmingLanguageGetByIdDto);
		}
		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
		{
			DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = await Mediator.Send(deleteProgrammingLanguageCommand);
			return Ok(deletedProgrammingLanguageDto);
		}
	}
}
