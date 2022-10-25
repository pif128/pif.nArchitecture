using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.DeleteKodlamaUserOperationClaim
{
	public class DeleteUserOperationClaimCommandValidator:AbstractValidator<DeleteKodlamaUserOperationClaimCommand>
	{
		public DeleteUserOperationClaimCommandValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Id).GreaterThan(0);
		}
	}
}
