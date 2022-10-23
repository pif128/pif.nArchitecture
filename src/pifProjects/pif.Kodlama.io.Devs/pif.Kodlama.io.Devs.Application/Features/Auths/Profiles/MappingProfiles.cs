using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.Auths.Dtos;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Models;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetByIdGithubProfile;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Auths.Profiles
{

	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<KodlamaUser, KodlamaUserForLoginUserNameDto>().ReverseMap();
			CreateMap<KodlamaUser, KodlamaUserForRegisterDto>().ReverseMap();

		}
	}
}
