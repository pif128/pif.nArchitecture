using pif.Core.CrossCuttingConcerns.Exceptions;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
	public class ProgrammingLanguageBusinessRules
	{
		private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

		public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
		{
			_programmingLanguageRepository = programmingLanguageRepository;
		}

		public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
		{
			IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
			if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
		}


		public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage? programmingLanguage)
		{
			if (programmingLanguage == null) throw new BusinessException("Requested programming language does not exist");
		}


		public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenUpdated(string name)
		{
			IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
			if (result.Items.Count > 1) throw new BusinessException("Programming language name exists.");
		}
		public async Task ProgrammingLanguageShouldExistWhenDeleted(int? id)
		{
			ProgrammingLanguage? result = await _programmingLanguageRepository.GetAsync(x => x.Id == id);
			if (result == null) throw new BusinessException("Programming Language does not exist.");

		}

	}
}