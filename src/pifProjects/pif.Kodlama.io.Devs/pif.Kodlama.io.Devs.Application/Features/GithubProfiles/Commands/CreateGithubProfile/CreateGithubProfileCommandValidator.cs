using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
	public class CreateGithubProfileCommandValidator : AbstractValidator<CreateGithubProfileCommand>
	{
		public CreateGithubProfileCommandValidator()
		{
			RuleFor(x => x.UserId).NotEmpty();
			RuleFor(x => x.UserId).GreaterThan(0);
			RuleFor(x => x.GithubAddress).NotEmpty();
			RuleFor(x => x.GithubAddress).MinimumLength(2);
		}
	}
}
