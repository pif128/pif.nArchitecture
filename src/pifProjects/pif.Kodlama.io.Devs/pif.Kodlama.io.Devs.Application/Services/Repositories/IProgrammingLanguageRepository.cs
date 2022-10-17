using pif.Core.Persistence.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IProgrammingLanguageRepository :IAsyncRepository<ProgrammingLanguage>, IRepository<ProgrammingLanguage>
    {

    }
}
