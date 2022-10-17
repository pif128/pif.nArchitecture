using AutoMapper;
using MediatR;
using pif.Core.Application.Requests;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{

	public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
	{
		public PageRequest PageRequest { get; set; }
		public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
		{
			private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
			private readonly IMapper _mapper;

			public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
			{
				_programmingLanguageRepository = programmingLanguageRepository;
				_mapper = mapper;
			}

			public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
			{
				IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

				ProgrammingLanguageListModel mappedProgrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);

				return mappedProgrammingLanguageListModel;
			}
		}
	}
}
