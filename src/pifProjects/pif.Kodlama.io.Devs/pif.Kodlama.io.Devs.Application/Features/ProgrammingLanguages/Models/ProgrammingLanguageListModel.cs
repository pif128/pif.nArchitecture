using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;

namespace pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel : BasePageableModel
    {
        public IList<GetListProgrammingLanguageDto> Items { get; set; }

        //
    }
}
