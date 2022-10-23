using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology
{
	public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
	{
		public CreateTechnologyCommandValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.ProgmammingLanguageId).NotEmpty();
			RuleFor(x => x.ProgmammingLanguageId).GreaterThan(0);
			RuleFor(x => x.Name).MinimumLength(2);
		}
	}
}
