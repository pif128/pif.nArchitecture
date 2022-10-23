using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
	public class UpdateGithubProfileCommandValidator:AbstractValidator<UpdateGithubProfileCommand>
	{
		public UpdateGithubProfileCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Id).GreaterThan(0);
			RuleFor(x => x.UserId).NotEmpty();
			RuleFor(x => x.UserId).GreaterThan(0);
			RuleFor(x => x.GithubAddress).NotEmpty();
			RuleFor(x => x.GithubAddress).MinimumLength(2);
		}
	}
}
