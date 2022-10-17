using Microsoft.AspNetCore.Mvc;
using pif.Core.Application.Requests;
using pif.RentACar.Application.Features.Brands.Commands.CreateBrand;
using pif.RentACar.Application.Features.Brands.Dtos;
using pif.RentACar.Application.Features.Brands.Models;
using pif.RentACar.Application.Features.Brands.Queries.GetByIdBrand;
using pif.RentACar.Application.Features.Brands.Queries.GetListBrand;

namespace pif.RentACar.WebAPI.Controllers
{
	public class BrandsController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
		{
			CreatedBrandDto result = await Mediator.Send(createBrandCommand);
			return Created("", result);
		}

		[HttpGet]
		public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
		{
			GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
			BrandListModel result = await Mediator.Send(getListBrandQuery);
			return Ok(result);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdIdBrandQuery)
		{
			BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdIdBrandQuery);
			return Ok(brandGetByIdDto);
		}
	}
}
