using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.CreateKodlamaUserOperationClaim
{
	public class CreateKodlamaUserOperationClaimCommandValidator:AbstractValidator<CreateKodlamaUserOperationClaimCommand>
	{
		public CreateKodlamaUserOperationClaimCommandValidator()
		{
			RuleFor(x => x.UserId).NotNull();
			RuleFor(x => x.UserId).GreaterThan(0);
			RuleFor(x => x.OperationClaimId).NotNull();
			RuleFor(x => x.OperationClaimId).GreaterThan(0);

		}
	}
}
