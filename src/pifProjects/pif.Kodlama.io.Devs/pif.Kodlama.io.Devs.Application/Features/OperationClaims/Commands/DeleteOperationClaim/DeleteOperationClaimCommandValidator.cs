using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
	public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
	{
		public DeleteOperationClaimCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Id).NotEqual(0);
		}
	}
}
