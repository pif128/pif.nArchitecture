using AutoMapper;
using MediatR;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public partial class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
	{
		public int Id { get; set; }

		public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
		{
			private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
			private readonly IMapper _mapper;
			private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

			public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
			{
				_programmingLanguageRepository = programmingLanguageRepository;
				_mapper = mapper;
				_programmingLanguageBusinessRules = programmingLanguageBusinessRules;
			}

			public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
			{

				ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
				ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(mappedProgrammingLanguage);
				DeletedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(updatedProgrammingLanguage);

				return updatedProgrammingLanguageDto;

			}
		}
	}
}
