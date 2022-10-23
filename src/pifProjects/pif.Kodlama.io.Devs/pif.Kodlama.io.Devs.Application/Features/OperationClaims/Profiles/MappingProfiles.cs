using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Models;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetByIdGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Profiles
{

	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
			CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();

			CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
			CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();

			CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
			CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();



			CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();

			CreateMap<OperationClaim, GetListOperationClaimDto>().ReverseMap();
			CreateMap<OperationClaim, GetByIdOperationClaimDto>().ReverseMap();

			CreateMap<OperationClaim, GetByIdGithubProfileQuery>().ReverseMap();
		}
	}
}
