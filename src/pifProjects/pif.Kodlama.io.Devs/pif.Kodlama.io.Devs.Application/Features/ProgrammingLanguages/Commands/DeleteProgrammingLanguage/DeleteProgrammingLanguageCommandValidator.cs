using FluentValidation;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
	public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
	{
		public DeleteProgrammingLanguageCommandValidator()
		{
			RuleFor(c => c.Id).NotEmpty();
		}
	}
}
