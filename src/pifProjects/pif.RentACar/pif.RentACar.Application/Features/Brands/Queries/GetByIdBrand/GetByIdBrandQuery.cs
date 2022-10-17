using AutoMapper;
using MediatR;
using pif.RentACar.Application.Features.Brands.Dtos;
using pif.RentACar.Application.Features.Brands.Rules;
using pif.RentACar.Application.Services.Repositories;
using pif.RentACar.Domain.Entities;

namespace pif.RentACar.Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery:IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
               Brand? brand =  await _brandRepository.GetAsync(b=>b.Id==request.Id);

               _brandBusinessRules.BrandShouldExistWhenRequested(brand);

               BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brand);
               return brandGetByIdDto;
            }
        }
    }
}
