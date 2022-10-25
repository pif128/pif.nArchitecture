using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Models;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Profiles
{

	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Technology, CreatedTechnologyDto>()
				.ForMember(x => x.ProgramminLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
				.ReverseMap();
			CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

			CreateMap<Technology, UpdatedTechnologyDto>()
				.ForMember(x => x.ProgramminLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
				.ReverseMap();
			CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

			CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
			CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();



			CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();

			CreateMap<Technology, GetListTechnologyDto>()
				.ForMember(x => x.ProgramminLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
				.ReverseMap();
			CreateMap<Technology, GetByIdTechnologyDto>()
				.ForMember(x => x.ProgramminLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
				.ReverseMap();

			CreateMap<Technology, GetByIdTechnologyQuery>().ReverseMap();
			//CreateMap<IPaginate<Technology>, GetByIdTechnologyQuery>().ReverseMap();
		}
	}
}
