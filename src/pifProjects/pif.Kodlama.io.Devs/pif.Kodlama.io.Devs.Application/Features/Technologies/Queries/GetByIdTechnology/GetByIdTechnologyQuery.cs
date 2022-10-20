using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology
{
	public class GetByIdTechnologyQuery : IRequest<GetByIdTechnologyDto>
	{
		public int Id { get; set; }

		public class GetByIdTecnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDto>
		{
			private readonly ITechnologyRepository _technologyRepository;
			private readonly IMapper _mapper;
			private readonly TechnologyBusinessRules _technologyBusinessRules;

			public GetByIdTecnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
			{
				_technologyRepository = technologyRepository;
				_mapper = mapper;
				_technologyBusinessRules = technologyBusinessRules;
			}

			public async Task<GetByIdTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
			{
				Technology? technology = await _technologyRepository.GetAsync(x => x.Id == request.Id,
					include:x=>x.Include(c=>c.ProgrammingLanguage));
				_technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);
				GetByIdTechnologyDto technologyGetByIdDto = _mapper.Map<GetByIdTechnologyDto>(technology);

				return technologyGetByIdDto;
			}
		}
	}
}
