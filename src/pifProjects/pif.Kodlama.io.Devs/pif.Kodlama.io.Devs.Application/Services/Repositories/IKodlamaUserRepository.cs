using pif.Core.Persistence.Repositories;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Services.Repositories
{
	public interface IKodlamaUserRepository : IAsyncRepository<KodlamaUser>, IRepository<KodlamaUser>
	{
	}
}
