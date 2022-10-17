using AutoMapper;
using pif.Core.Persistence.Paging;
using pif.RentACar.Application.Features.Brands.Commands.CreateBrand;
using pif.RentACar.Application.Features.Brands.Dtos;
using pif.RentACar.Application.Features.Brands.Models;
using pif.RentACar.Domain.Entities;

namespace pif.RentACar.Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand,CreatedBrandDto>().ReverseMap();
            CreateMap<Brand,CreateBrandCommand>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
            CreateMap<Brand,BrandListDto>().ReverseMap();
            CreateMap<Brand, BrandGetByIdDto>().ReverseMap();
        }
    }
}
