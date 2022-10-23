using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
	public class GetByIdProgrammingLanguageQueryValidator : AbstractValidator<GetByIdProgrammingLanguageQuery>
	{
		public GetByIdProgrammingLanguageQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Id).GreaterThan(0);
		}
	}
}
