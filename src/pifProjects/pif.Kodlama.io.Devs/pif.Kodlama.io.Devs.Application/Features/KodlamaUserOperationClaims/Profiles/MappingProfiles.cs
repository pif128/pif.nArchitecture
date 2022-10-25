using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.CreateKodlamaUserOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.DeleteKodlamaUserOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.KodlamaUpdateUserOperationClaim;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Models;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Queries.GetByIdKodlamaUserOperationClaim;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Profiles
{

	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<KodlamaUserOperationClaim, CreatedKodlamaUserOperationClaimDto>()
				.ForMember(x => x.UserName, opt => opt.MapFrom(c => c.KodlamaUser.UserName))
				.ForMember(x => x.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
				.ReverseMap();
			CreateMap<UserOperationClaim, CreateKodlamaUserOperationClaimCommand>().ReverseMap();

			CreateMap<KodlamaUserOperationClaim, UpdatedKodlamaUserOperationClaimDto>()
				.ForMember(x => x.UserName, opt => opt.MapFrom(c => c.KodlamaUser.UserName))
				.ForMember(x => x.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
				.ReverseMap();
			CreateMap<KodlamaUserOperationClaim, UpdateKodlamaUserOperationClaimCommand>()
				.ReverseMap();

			CreateMap<KodlamaUserOperationClaim, DeletedKodlamaUserOperationClaimDto>().ReverseMap();
			CreateMap<KodlamaUserOperationClaim, DeleteKodlamaUserOperationClaimCommand>().ReverseMap();



			CreateMap<IPaginate<KodlamaUserOperationClaim>, KodlamaUserOperationClaimListModel>().ReverseMap();

			CreateMap<KodlamaUserOperationClaim, GetListKodlamaUserOperationClaimDto>()
				.ForMember(x => x.UserName, opt => opt.MapFrom(c => c.KodlamaUser.UserName))
				.ForMember(x => x.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
				.ReverseMap();
			CreateMap <KodlamaUserOperationClaim, GetByIdKodlamaUserOperationClaimDto>()
				.ForMember(x => x.UserName, opt => opt.MapFrom(c => c.KodlamaUser.UserName))
				.ForMember(x => x.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
				.ReverseMap();

			CreateMap <KodlamaUserOperationClaim, GetByIdKodlamUserOperationClaimQuery>()
				.ReverseMap();
		}
	}
}
