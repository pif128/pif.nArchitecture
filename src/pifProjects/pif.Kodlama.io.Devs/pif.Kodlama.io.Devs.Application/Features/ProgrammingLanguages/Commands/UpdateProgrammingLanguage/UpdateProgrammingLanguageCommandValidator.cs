using FluentValidation;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
	public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
	{
		public UpdateProgrammingLanguageCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Id).GreaterThan(0);
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Name).MinimumLength(2);
		}
	}
}
