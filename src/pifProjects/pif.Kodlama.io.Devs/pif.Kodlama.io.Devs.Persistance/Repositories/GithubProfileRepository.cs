using pif.Core.Persistence.Repositories;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using pif.Kodlama.io.Devs.Persistance.Contexts;

namespace pif.Kodlama.io.Devs.Persistance.Repositories
{
	public class GithubProfileRepository : EfRepositoryBase<GithubProfile, BaseDbContext>, IGithubProfileRepository
	{
		public GithubProfileRepository(BaseDbContext context) : base(context)
		{
		}

	}
}