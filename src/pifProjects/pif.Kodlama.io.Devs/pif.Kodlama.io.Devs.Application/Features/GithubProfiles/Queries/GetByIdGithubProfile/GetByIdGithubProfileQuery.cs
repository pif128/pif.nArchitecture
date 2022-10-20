using MediatR;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetByIdGithubProfile
{
	public class GetByIdGithubProfileQuery:IRequest<GetByIdGithubProfileDto>
	{
	}
}
