using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
	public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
	{
		public UpdateTechnologyCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Id).GreaterThan(0);
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.ProgrammingLanguageId).NotEmpty();
			RuleFor(x => x.ProgrammingLanguageId).GreaterThan(0);
			RuleFor(x => x.Name).MinimumLength(2);
		}
	}
}
