using pif.Core.Persistence.Repositories;
using pif.RentACar.Application.Services.Repositories;
using pif.RentACar.Domain.Entities;
using pif.RentACar.Pesistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.RentACar.Pesistence.Repositories
{

	public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
	{
		public BrandRepository(BaseDbContext context) : base(context)
		{
		}

	}
}
