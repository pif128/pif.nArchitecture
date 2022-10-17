using pif.Core.Persistence.Repositories;
using pif.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.RentACar.Application.Services.Repositories
{
	public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
	{
	}
}
