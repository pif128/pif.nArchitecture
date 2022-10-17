using pif.Core.Persistence.Repositories;
using pif.Core.Security.Entities;
using pif.RentACar.Application.Services.Repositories;
using pif.RentACar.Pesistence.Contexts;

namespace pif.RentACar.Pesistence.Repositories
{
	public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
	{
		public RefreshTokenRepository(BaseDbContext context) : base(context)
		{
		}
	}
}
