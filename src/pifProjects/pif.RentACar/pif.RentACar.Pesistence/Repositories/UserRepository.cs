using pif.Core.Persistence.Repositories;
using pif.Core.Security.Entities;
using pif.RentACar.Application.Services.Repositories;
using pif.RentACar.Pesistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.RentACar.Pesistence.Repositories
{
	public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
	{
		public UserRepository(BaseDbContext context) : base(context)
		{
		}
	}
}
