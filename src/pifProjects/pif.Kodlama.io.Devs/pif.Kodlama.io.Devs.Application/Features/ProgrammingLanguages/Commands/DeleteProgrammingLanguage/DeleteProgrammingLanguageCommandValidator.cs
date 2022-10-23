using FluentValidation;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
	public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
	{
		public DeleteProgrammingLanguageCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Id).GreaterThan(0);
		}
	}
}
