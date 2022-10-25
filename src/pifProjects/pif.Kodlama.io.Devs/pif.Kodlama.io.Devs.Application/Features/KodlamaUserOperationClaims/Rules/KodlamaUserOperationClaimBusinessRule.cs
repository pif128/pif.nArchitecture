using pif.Core.CrossCuttingConcerns.Exceptions;
using pif.Core.Persistence.Paging;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Rules
{
	public class KodlamaUserOperationClaimBusinessRule
	{
		IKodlamaUserRepository _kodlamaUserRepository;
		IOperationClaimRepository _operationClaimRepository;
		IKodlamaUserOperationClaimRepository _kodlamaUserOperationClaimRepository;

		public KodlamaUserOperationClaimBusinessRule(IKodlamaUserRepository kodlamaUserRepository, IOperationClaimRepository operationClaimRepository, IKodlamaUserOperationClaimRepository userOperationClaimRepository)
		{
			_kodlamaUserRepository = kodlamaUserRepository;
			_operationClaimRepository = operationClaimRepository;
			_kodlamaUserOperationClaimRepository = userOperationClaimRepository;
		}

		public async Task UserOperationClaimCanNotBeDuplicatedWhenInserted(int userId, int operationClaimId)
		{
			UserOperationClaim? result = await _kodlamaUserOperationClaimRepository.GetAsync(x => x.UserId == userId && x.OperationClaimId == operationClaimId);
			if (result != null) throw new BusinessException("this has been added before");

		}
		public async Task UserShoultExistWhenInserted(int userId)
		{
			KodlamaUser? result = await _kodlamaUserRepository.GetAsync(x => x.Id == userId);
			if (result == null) throw new BusinessException("User does not exist");

		}
		public async Task OperationClaimShoultExistWhenInserted(int operationClaimId)
		{
			OperationClaim? result = await _operationClaimRepository.GetAsync(x => x.Id == operationClaimId);
			if (result == null) throw new BusinessException("Operation Claim does not exist");

		}
		public async Task UserOperationClaimShoultExistWhenDeleted(int userOperationClaimId)
		{
			UserOperationClaim? result = await _kodlamaUserOperationClaimRepository.GetAsync(x => x.Id == userOperationClaimId);
			if (result == null) throw new BusinessException("User Operation Claim does not exist");

		}
		public async Task UserShoultExistWhenUpdated(int userId)
		{
			KodlamaUser? result = await _kodlamaUserRepository.GetAsync(x => x.Id == userId);
			if (result == null) throw new BusinessException("User does not exist");

		}
		public async Task OperationClaimShoultExistWhenUpdated(int operationClaimId)
		{
			OperationClaim? result = await _operationClaimRepository.GetAsync(x => x.Id == operationClaimId);
			if (result == null) throw new BusinessException("Operation Claim does not exist");

		}
		public async Task UserOperationClaimShoultExistWhenUpdated(int userOperationClaimId)
		{
			UserOperationClaim? result = await _kodlamaUserOperationClaimRepository.GetAsync(x => x.Id == userOperationClaimId, null, false);
			if (result == null) throw new BusinessException("User Operation Claim does not exist");

		}
		public async Task UserOperationClaimCanNotBeDuplicatedWhenUpdated(int userId, int operationCalimId)
		{
			IPaginate<KodlamaUserOperationClaim> result = await _kodlamaUserOperationClaimRepository.GetListAsync(x => x.UserId == userId && x.OperationClaimId == operationCalimId);
			if (result.Items.Count > 1) throw new BusinessException("User Operation Claim exists.");
		}


		public async Task UserOperationClaimShoultExistWhenRequest(int userOperationClaimId)
		{
			UserOperationClaim? result = await _kodlamaUserOperationClaimRepository.GetAsync(x => x.Id == userOperationClaimId);
			if (result == null) throw new BusinessException("User Operation Claim does not exist");

		}
	}
}
