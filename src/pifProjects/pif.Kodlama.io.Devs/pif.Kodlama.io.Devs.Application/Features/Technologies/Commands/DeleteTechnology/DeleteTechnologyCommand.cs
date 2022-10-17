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

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology
{
	public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
	{
		public int Id { get; set; }
		public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
		{
			private readonly ITechnologyRepository _technologyRepository;
			private readonly IMapper _mapper;
			private readonly TechnologyBusinessRules _technologyBusinessRules;

			public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
			{
				_technologyRepository = technologyRepository;
				_mapper = mapper;
				_technologyBusinessRules = technologyBusinessRules;
			}

			public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
			{
				Technology mappedTechnology = _mapper.Map<Technology>(request);
				Technology deletedTechnology = await _technologyRepository.DeleteAsync(mappedTechnology);

				DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
				return deletedTechnologyDto;
			}
		}
	}
}
