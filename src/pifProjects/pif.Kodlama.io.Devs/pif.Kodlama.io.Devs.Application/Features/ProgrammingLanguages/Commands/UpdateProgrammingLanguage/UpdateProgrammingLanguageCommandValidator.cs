using FluentValidation;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
	public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
	{
		public UpdateProgrammingLanguageCommandValidator()
		{
			RuleFor(c => c.Name).NotEmpty();
			RuleFor(c => c.Name).MinimumLength(2);
		}
	}
}
