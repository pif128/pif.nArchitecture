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
	public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>,IRefreshTokenRepository
	{
		public RefreshTokenRepository(BaseDbContext context) : base(context)
		{
		}
	}
}
