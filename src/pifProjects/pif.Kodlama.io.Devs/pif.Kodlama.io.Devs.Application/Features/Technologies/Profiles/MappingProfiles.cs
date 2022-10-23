using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Models;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



			CreateMap<IPaginate<Technology>, ListTechnologyModel>().ReverseMap();

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
