using pif.Core.Persistence.Repositories;
using pif.Core.Security.Entities;
using pif.RentACar.Application.Services.Repositories;
using pif.RentACar.Pesistence.Contexts;

namespace pif.RentACar.Pesistence.Repositories
{
	public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
	{
		public OperationClaimRepository(BaseDbContext context) : base(context)
		{
		}
	}
}
