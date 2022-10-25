using FluentValidation;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.KodlamaUpdateUserOperationClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.UpdateUserOperationClaim
{
	public class UpdateKodlamaUserOperationClaimCommandValidator:AbstractValidator<UpdateKodlamaUserOperationClaimCommand>
	{
		public UpdateKodlamaUserOperationClaimCommandValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Id).GreaterThan(0);
			RuleFor(x => x.UserId).NotNull();
			RuleFor(x => x.UserId).GreaterThan(0);
			RuleFor(x => x.OperationClaimId).NotNull();
			RuleFor(x => x.OperationClaimId).GreaterThan(0);
		}
	}
}
