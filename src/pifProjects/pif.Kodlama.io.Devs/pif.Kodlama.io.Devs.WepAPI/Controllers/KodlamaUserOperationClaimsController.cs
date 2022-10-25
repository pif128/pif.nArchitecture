using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pif.Core.Application.Requests;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.CreateKodlamaUserOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.DeleteKodlamaUserOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.KodlamaUpdateUserOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Models;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Queries.GetByIdKodlamaUserOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Queries.GetListKodlamaUserOperationClaim;

namespace pif.Kodlama.io.Devs.WepAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KodlamaUserOperationClaimsController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateKodlamaUserOperationClaimCommand createKodlamaUserOperationClaimCommand)
		{
			CreatedKodlamaUserOperationClaimDto createdKodlamaUserOperationClaimDto = await Mediator.Send(createKodlamaUserOperationClaimCommand);
			return Created("", createdKodlamaUserOperationClaimDto);
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateKodlamaUserOperationClaimCommand updateKodlamaUserOperationClaimCommand)
		{
			UpdatedKodlamaUserOperationClaimDto updatedKodlamaUserOperationClaimDto = await Mediator.Send(updateKodlamaUserOperationClaimCommand);
			return Created("", updatedKodlamaUserOperationClaimDto);
		}
		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete([FromRoute] DeleteKodlamaUserOperationClaimCommand deleteKodlamaUserOperationClaimCommand)
		{
			DeletedKodlamaUserOperationClaimDto deletedKodlamaUserOperationClaimDto = await Mediator.Send(deleteKodlamaUserOperationClaimCommand);
			return Ok(deletedKodlamaUserOperationClaimDto);
		}
		[HttpGet("{Id}")]
		public async Task<IActionResult> GetById([FromRoute] GetByIdKodlamUserOperationClaimQuery getByIdKodlamUserOperationClaimQuery)
		{
			GetByIdKodlamaUserOperationClaimDto getByIdKodlamaUserOperationClaimDto = await Mediator.Send(getByIdKodlamUserOperationClaimQuery);
			return Ok(getByIdKodlamaUserOperationClaimDto);
		}
		[HttpGet]
		public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
		{
			GetListKodlamaUserOperationClaimQuery getListKodlamaUserOperationClaimQuery = new() { PageRequest = pageRequest };
			KodlamaUserOperationClaimListModel kodlamaUserOperationClaimListModel = await Mediator.Send(getListKodlamaUserOperationClaimQuery);
			return Ok(kodlamaUserOperationClaimListModel);
		}
	}
}
