using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Core.Application.Requests;
using pif.Core.Persistence.Paging;
using pif.RentACar.Application.Features.Models.Models;
using pif.RentACar.Application.Services.Repositories;
using pif.RentACar.Domain.Entities;

namespace pif.RentACar.Application.Features.Models.Queries.GetListModel
{
    public class GetListModelQuery:IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
        {

            private readonly IMapper _mapper;
            private readonly IModelRepository _modelRepository;

            public GetListModelQueryHandler(IMapper mapper, IModelRepository modelRepository)
            {
                _mapper = mapper;
                _modelRepository = modelRepository;
            }

            public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                                 //car models
                IPaginate<Model> models = await _modelRepository.GetListAsync(include: 
                                              m=>m.Include(c=>c.Brand),
                                              index:request.PageRequest.Page,
                                              size:request.PageRequest.PageSize
                                              );
                               //dataModel
                ModelListModel mappedModels = _mapper.Map<ModelListModel>(models);
                return mappedModels;
            }
        }
    }
}
