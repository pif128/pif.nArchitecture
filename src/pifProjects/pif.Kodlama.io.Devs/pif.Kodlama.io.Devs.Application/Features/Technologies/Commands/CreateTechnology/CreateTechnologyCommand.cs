using AutoMapper;
using MediatR;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology
{
	public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
	{
		public string Name { get; set; }
		public int? ProgmammingLanguageId { get; set; }

		public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
		{
			ITechnologyRepository _technologyRepository;
			IMapper _mapper;
			TechnologyBusinessRules _technologyBusinessRules;

			public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
			{
				_technologyRepository = technologyRepository;
				_mapper = mapper;
				_technologyBusinessRules = technologyBusinessRules;
			}

			public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
			{
				await _technologyBusinessRules.TechnologyCanNotBeDuplicatedWhenInserted(request.Name);
				await _technologyBusinessRules.TechnologyShouldBeProgrammingLanguageIdWhenInserted(request.ProgmammingLanguageId);

				Technology mappedTechnology = _mapper.Map<Technology>(request);
				Technology createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
				CreatedTechnologyDto createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnology);

				return createdTechnologyDto;

			}
		}
	}
}
