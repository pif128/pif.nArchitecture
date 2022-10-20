using AutoMapper;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Profiles
{
	public class MappingProfiles:Profile
	{
		public MappingProfiles()
		{
			CreateMap<GithubProfile, CreatedGithubProfileDto>().ReverseMap();
			CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();

			CreateMap<GithubProfile, UpdatedGithubProfileDto>().ReverseMap();
			CreateMap<GithubProfile, UpdateGithubProfileCommand>().ReverseMap();

			CreateMap<GithubProfile, DeletedGithubProfileDto>().ReverseMap();
			//CreateMap<GithubProfile, DeleteGithubProfileCommand>().ReverseMap();



			//CreateMap<IPaginate<GithubProfile>, GithubProfileListModel>().ReverseMap();

			//CreateMap<GithubProfile, GithubProfileListDto>()
			//	.ForMember(x => x.ProgramminLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
			//	.ReverseMap();
			//CreateMap<GithubProfile, GithubProfileGetByIdDto>()
			//	.ForMember(x => x.ProgramminLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
			//	.ReverseMap();

			//CreateMap<GithubProfile, GetByIdGithubProfileQuery>().ReverseMap();
		}
	}
}
