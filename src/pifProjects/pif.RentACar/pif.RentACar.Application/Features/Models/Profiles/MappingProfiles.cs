using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.RentACar.Application.Features.Models.Dtos;
using pif.RentACar.Application.Features.Models.Models;
using pif.RentACar.Domain.Entities;

namespace pif.RentACar.Application.Features.Models.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>()
                .ForMember(c=>c.BrandName, opt=>opt.MapFrom(c=>c.Brand.Name))
                .ReverseMap();

            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        }
    }
}
