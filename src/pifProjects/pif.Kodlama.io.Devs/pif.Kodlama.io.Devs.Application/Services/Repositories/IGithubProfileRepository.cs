using pif.Core.Persistence.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Services.Repositories
{
	public interface IGithubProfileRepository : IAsyncRepository<GithubProfile>, IRepository<GithubProfile>
    {

    }
}
