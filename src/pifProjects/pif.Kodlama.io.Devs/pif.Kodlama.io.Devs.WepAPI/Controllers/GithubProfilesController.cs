using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pif.Core.Application.Requests;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Models;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetByIdGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetListGithubProfile;
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
	public class GithubProfilesController : BaseController
	{
		[HttpPost]
		//[Authorize(Policy = "AdminForCreate")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromBody] CreateGithubProfileCommand createGithubProfileCommand)
		{
			CreatedGithubProfileDto createdGithubProfileDto = await Mediator.Send(createGithubProfileCommand);
			return Created("", createdGithubProfileDto);
		}
		[HttpPut]
		//[Authorize(Policy = "AdminForUpdate")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Update([FromBody] UpdateGithubProfileCommand updateGithubProfileCommand)
		{
			UpdatedGithubProfileDto updatedGithubProfileDto = await Mediator.Send(updateGithubProfileCommand);
			return Created("", updatedGithubProfileDto);
		}
		[HttpDelete("{Id}")]
		//[Authorize(Policy = "AdminForDelete")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete([FromRoute] DeleteGithubProfileCommand deleteGithubProfileCommand)
		{
			DeletedGithubProfileDto deletedGithubProfileDto = await Mediator.Send(deleteGithubProfileCommand);
			return Ok(deletedGithubProfileDto);
		}
		[HttpGet]
		//[Authorize(Policy = "AdminForGetList")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
		{
			GetListGithubProfileQuery getListGithubProfileQuery = new() { PageRequest = pageRequest };
			GithubProfileListModel githubProfileListModel = await Mediator.Send(getListGithubProfileQuery);
			return Ok(githubProfileListModel);
		}
		[HttpGet("{Id}")]
		//[Authorize(Policy = "AdminForGetById")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetById([FromRoute] GetByIdGithubProfileQuery getByIdGithubProfileQuery)
		{
			GetByIdGithubProfileDto getByIdGithubProfileDto = await Mediator.Send(getByIdGithubProfileQuery);
			return Ok(getByIdGithubProfileDto);
		}
	}
}
