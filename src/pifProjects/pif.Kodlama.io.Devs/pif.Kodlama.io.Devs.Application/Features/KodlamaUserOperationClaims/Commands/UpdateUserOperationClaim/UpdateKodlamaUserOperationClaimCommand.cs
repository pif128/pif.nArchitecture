using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.KodlamaUpdateUserOperationClaim
{
	public class UpdateKodlamaUserOperationClaimCommand : IRequest<UpdatedKodlamaUserOperationClaimDto>
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int OperationClaimId { get; set; }

		public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateKodlamaUserOperationClaimCommand, UpdatedKodlamaUserOperationClaimDto>
		{
			private readonly IKodlamaUserOperationClaimRepository _kodlamaUserOperationClaimRepository;
			private readonly IMapper _mapper;
			private readonly KodlamaUserOperationClaimBusinessRule _kodlamaUserOperationClaimBusinessRule;

			public UpdateUserOperationClaimCommandHandler(IKodlamaUserOperationClaimRepository kodlamaUserOperationClaimRepository, IMapper mapper, KodlamaUserOperationClaimBusinessRule kodlamaUserOperationClaimBusinessRule)
			{
				_kodlamaUserOperationClaimRepository = kodlamaUserOperationClaimRepository;
				_mapper = mapper;
				_kodlamaUserOperationClaimBusinessRule = kodlamaUserOperationClaimBusinessRule;
			}

			public async Task<UpdatedKodlamaUserOperationClaimDto> Handle(UpdateKodlamaUserOperationClaimCommand request, CancellationToken cancellationToken)
			{
				await _kodlamaUserOperationClaimBusinessRule.UserOperationClaimShoultExistWhenUpdated(request.Id);
				await _kodlamaUserOperationClaimBusinessRule.UserShoultExistWhenUpdated(request.UserId);
				await _kodlamaUserOperationClaimBusinessRule.OperationClaimShoultExistWhenUpdated(request.OperationClaimId);
				await _kodlamaUserOperationClaimBusinessRule.UserOperationClaimCanNotBeDuplicatedWhenUpdated(request.UserId, request.OperationClaimId);


				KodlamaUserOperationClaim mappedKodlamaUserOperationClaim = _mapper.Map<KodlamaUserOperationClaim>(request);
				KodlamaUserOperationClaim updatedKodlamaUserOperationClaim = await _kodlamaUserOperationClaimRepository.UpdateAsync(mappedKodlamaUserOperationClaim);
				KodlamaUserOperationClaim includedkodlamaUserOperationClaim =await _kodlamaUserOperationClaimRepository.GetAsync(x=>x.Id==updatedKodlamaUserOperationClaim.Id,include:x=>x.Include(c=>c.KodlamaUser).Include(c=>c.OperationClaim));

				UpdatedKodlamaUserOperationClaimDto updatedUserOperationClaimDto = _mapper.Map<UpdatedKodlamaUserOperationClaimDto>(includedkodlamaUserOperationClaim);

				return updatedUserOperationClaimDto;
			}
		}
	}
}
