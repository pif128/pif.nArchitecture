using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
			CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

			CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
			CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

			CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
			CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();



			CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();

			CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
			CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
		}
	}
}
