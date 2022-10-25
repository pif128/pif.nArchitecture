using pif.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Domain.Entities
{
	public class KodlamaUserOperationClaim : UserOperationClaim
	{
		public int KodlamaUserId { get; set; }
		public virtual KodlamaUser KodlamaUser { get; set; }

		public KodlamaUserOperationClaim()
		{
		}

		public KodlamaUserOperationClaim(int id, int userId, int operationClaimId) : base(id, userId, operationClaimId)
		{
			this.KodlamaUserId = id;
		}
	}

}
