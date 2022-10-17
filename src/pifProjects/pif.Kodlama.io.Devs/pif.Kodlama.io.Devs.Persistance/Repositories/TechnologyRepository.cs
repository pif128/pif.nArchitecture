using pif.Core.Persistence.Repositories;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using pif.Kodlama.io.Devs.Persistance.Contexts;

namespace pif.Kodlama.io.Devs.Persistance.Repositories
{
	public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
	{
		public TechnologyRepository(BaseDbContext context) : base(context)
		{
		}

	}
}