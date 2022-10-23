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
using System.Xml.Linq;

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Rules
{
	public class OperationClaimBusinessRule
	{
		private readonly IOperationClaimRepository _operationClaimRepository;

		public OperationClaimBusinessRule(IOperationClaimRepository operationClaimRepository)
		{
			_operationClaimRepository = operationClaimRepository;
		}
		public async Task OperationClaimCannotBeDuplicateWhenInserted(string name)
		{
			var operationClaim = await _operationClaimRepository.GetAsync(x => x.Name == name);
			if (operationClaim != null) throw new BusinessException("Operation Claim already exists.");
		}
		public async Task OperationClaimCannotBeDuplicateWhenUpdated(string name)
		{
			IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(x => x.Name == name);
			if (result.Items.Count > 1) throw new BusinessException("Operation Claim already exists.");
		}
		public void OperationClaimShouldExistWhenRequested(OperationClaim? operationClaim)
		{
			if (operationClaim == null) throw new BusinessException("Operation Claim does not exist.");
		}
		public async Task OperationClaimShouldExistWhenDeleted(int? id)
		{
			OperationClaim? result = await _operationClaimRepository.GetAsync(x => x.Id == id);
			if (result == null) throw new BusinessException("Operation Claim does not exist.");
		}
	}
}
