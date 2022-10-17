using Microsoft.AspNetCore.Mvc;
using pif.Core.Application.Requests;
using pif.Core.Persistence.Dynamic;
using pif.RentACar.Application.Features.Models.Models;
using pif.RentACar.Application.Features.Models.Queries.GetListModel;
using pif.RentACar.Application.Features.Models.Queries.GetListModelByDynamic;

namespace pif.RentACar.WebAPI.Controllers
{
	public class ModelsController : BaseController
	{
		[HttpGet]
		public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
		{
			GetListModelQuery getListModelQuery = new GetListModelQuery { PageRequest = pageRequest };
			ModelListModel result = await Mediator.Send(getListModelQuery);
			return Ok(result);

		}

		[HttpPost("GetList/ByDynamic")]
		public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
		{
			GetListModelByDynamicQuery getListByDynamicModelQuery = new GetListModelByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
			ModelListModel result = await Mediator.Send(getListByDynamicModelQuery);
			return Ok(result);

		}
	}
}
