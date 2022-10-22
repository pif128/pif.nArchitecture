using pif.Core.Persistence.Repositories;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Persistance.Repositories
{
	public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
	{
		public OperationClaimRepository(BaseDbContext context) : base(context)
		{
		}
	}
}
