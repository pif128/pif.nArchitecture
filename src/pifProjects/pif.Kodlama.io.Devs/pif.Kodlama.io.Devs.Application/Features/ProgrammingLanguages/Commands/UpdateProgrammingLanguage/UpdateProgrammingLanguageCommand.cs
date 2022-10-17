using AutoMapper;
using MediatR;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public partial class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
	{
		public string Name { get; set; }

		public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
		{
			private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
			private readonly IMapper _mapper;
			private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

			public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
			{
				_programmingLanguageRepository = programmingLanguageRepository;
				_mapper = mapper;
				_programmingLanguageBusinessRules = programmingLanguageBusinessRules;
			}

			public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
			{
				await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenUpdated(request.Name);

				ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
				ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
				UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);

				return updatedProgrammingLanguageDto;

			}
		}
	}
}
