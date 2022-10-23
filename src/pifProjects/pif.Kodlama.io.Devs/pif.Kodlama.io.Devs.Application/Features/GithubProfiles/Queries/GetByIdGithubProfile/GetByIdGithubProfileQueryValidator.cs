using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetByIdGithubProfile
{
	public class GetByIdGithubProfileQueryValidator : AbstractValidator<GetByIdGithubProfileQuery>
	{
		public GetByIdGithubProfileQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Id).GreaterThan(0);
		}
	}
}
