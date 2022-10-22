using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Models;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetByIdGithubProfile;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Profiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<GithubProfile, CreatedGithubProfileDto>().ReverseMap();
			CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();

			CreateMap<GithubProfile, UpdatedGithubProfileDto>()
				.ForMember(x => x.UserId, opt => opt.MapFrom(c => c.User.Id))
				.ReverseMap();
			CreateMap<GithubProfile, UpdateGithubProfileCommand>().ReverseMap();

			CreateMap<GithubProfile, DeletedGithubProfileDto>().ReverseMap();
			CreateMap<GithubProfile, DeleteGithubProfileCommand>().ReverseMap();



			CreateMap<IPaginate<GithubProfile>, GithubProfileListModel>().ReverseMap();

			CreateMap<GithubProfile, GetListGithubProfiledDto>()
				.ForMember(x => x.UserId, opt => opt.MapFrom(c => c.User.Id))
				.ReverseMap();
			CreateMap<GithubProfile, GetByIdGithubProfileDto>()
				.ForMember(x => x.UserId, opt => opt.MapFrom(c => c.User.Id))
				.ReverseMap();

			CreateMap<GithubProfile, GetByIdGithubProfileQuery>().ReverseMap();
		}
	}
}
