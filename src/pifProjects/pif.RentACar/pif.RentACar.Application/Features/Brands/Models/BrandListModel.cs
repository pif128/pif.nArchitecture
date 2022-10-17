using pif.Core.Persistence.Paging;
using pif.RentACar.Application.Features.Brands.Dtos;

namespace pif.RentACar.Application.Features.Brands.Models
{
    public class BrandListModel:BasePageableModel
    {
        public IList<BrandListDto> Items { get; set; }

        //
    }
}
