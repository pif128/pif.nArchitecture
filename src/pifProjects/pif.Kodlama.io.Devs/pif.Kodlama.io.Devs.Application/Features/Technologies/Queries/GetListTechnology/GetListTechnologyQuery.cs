using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Core.Application.Requests;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Models;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology
{
	public class GetListTechnologyQuery : IRequest<TechnologyListModel>
	{
		public PageRequest PageRequest { get; set; }

		public class GetlistTechnologyHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
		{
			private readonly ITechnologyRepository _technologyRepository;
			private readonly IMapper _mapper;

			public GetlistTechnologyHandler(ITechnologyRepository technologyRepository, IMapper mapper)
			{
				_technologyRepository = technologyRepository;
				_mapper = mapper;
			}

			public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
			{
				IPaginate<Technology> tecnologies = await _technologyRepository.GetListAsync(include:
					x=>x.Include(c=>c.ProgrammingLanguage),
					index: request.PageRequest.Page, size: request.PageRequest.PageSize);

				TechnologyListModel mappedTechnologyListModel = _mapper.Map<TechnologyListModel>(tecnologies);

				return mappedTechnologyListModel;
			}
		}
	}
}
