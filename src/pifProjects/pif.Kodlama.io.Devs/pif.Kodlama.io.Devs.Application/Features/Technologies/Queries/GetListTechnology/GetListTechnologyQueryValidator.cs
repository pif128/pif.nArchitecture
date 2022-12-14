using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology
{
	public class GetListTechnologyQueryValidator:AbstractValidator<GetListTechnologyQuery>
	{
		public GetListTechnologyQueryValidator()
		{
			//RuleFor(x => x.PageRequest.Page).NotEmpty();
			RuleFor(x => x.PageRequest.Page).GreaterThanOrEqualTo(0);
			RuleFor(x => x.PageRequest.PageSize).NotEmpty();
			RuleFor(x => x.PageRequest.PageSize).GreaterThan(0);
		}
	}
}
