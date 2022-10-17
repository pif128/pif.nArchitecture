using pif.Core.Persistence.Paging;
using pif.RentACar.Application.Features.Models.Dtos;

namespace pif.RentACar.Application.Features.Models.Models
{
    public class ModelListModel:BasePageableModel
    {
        public IList<ModelListDto> Items { get; set; }
    }
}
