using pif.Core.Persistence.Repositories;
using pif.RentACar.Application.Services.Repositories;
using pif.RentACar.Domain.Entities;
using pif.RentACar.Pesistence.Contexts;

namespace pif.RentACar.Pesistence.Repositories
{

	public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
	{
		public ModelRepository(BaseDbContext context) : base(context)
		{
		}

	}
}
