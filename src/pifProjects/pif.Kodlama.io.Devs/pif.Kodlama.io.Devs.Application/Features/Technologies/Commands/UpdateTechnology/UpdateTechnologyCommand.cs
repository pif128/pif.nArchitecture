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

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
	public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
	{
		public string Name { get; set; }
		public int? ProgmammingLanguageId { get; set; }

		public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
		{
			private readonly ITechnologyRepository _technologyRepository;
			private readonly IMapper _mapper;
			private readonly TechnologyBusinessRules _technologyBusinessRules;

			public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
			{
				_technologyRepository = technologyRepository;
				_mapper = mapper;
				_technologyBusinessRules = technologyBusinessRules;
			}

			public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
			{
				await _technologyBusinessRules.TechnologyCanNotBeDuplicatedWhenUpdated(request.Name);
				await _technologyBusinessRules.TechnologyShouldBeProgrammingLanguageIdWhenUpdated(request.ProgmammingLanguageId);

				Technology mappedTechnology = _mapper.Map<Technology>(request);

				Technology updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);

				UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
				return updatedTechnologyDto;
			}
		}
	}
}
