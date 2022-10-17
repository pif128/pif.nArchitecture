using pif.Core.CrossCuttingConcerns.Exceptions;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Technologies.Rules
{
	public class TechnologyBusinessRules
	{
		private readonly ITechnologyRepository _technologyRepository;
		private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

		public TechnologyBusinessRules(ITechnologyRepository technologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
		{
			_technologyRepository = technologyRepository;
			_programmingLanguageRepository = programmingLanguageRepository;
		}

		public async Task TechnologyCanNotBeDuplicatedWhenInserted(string name)
		{
			IPaginate<Technology> result = await _technologyRepository.GetListAsync(x => x.Name == name);
			if (result.Items.Any()) throw new BusinessException("Technology name exists.");

		}

		public void TechnologyShouldExistWhenRequested(Technology? technology)
		{
			if (technology == null) throw new BusinessException("Technology does not exist.");
		}

		public async Task TechnologyShouldBeProgrammingLanguageIdWhenInserted(int? programmingLanguageId)
		{
			IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(x => x.Id == programmingLanguageId);
			if (!result.Items.Any()) throw new BusinessException("Programming Language does not exist.");

		}


		public async Task TechnologyCanNotBeDuplicatedWhenUpdated(string name)
		{
			IPaginate<Technology> result = await _technologyRepository.GetListAsync(x => x.Name == name);
			if (result.Items.Count > 1) throw new BusinessException("Technology name exists.");

		}
		public async Task TechnologyShouldBeProgrammingLanguageIdWhenUpdated(int? programmingLanguageId)
		{
			IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(x => x.Id == programmingLanguageId);
			if (!result.Items.Any()) throw new BusinessException("Programming Language does not exist.");

		}
	}
}
