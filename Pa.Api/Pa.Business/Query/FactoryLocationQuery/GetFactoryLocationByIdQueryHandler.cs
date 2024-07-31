using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.Query.FactoryLocationQuery
{
    public class GetFactoryLocationByIdQueryHandler : IRequestHandler<GetFactoryLocationByIdQuery, ApiResponse<FactoryLocationResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFactoryLocationByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<FactoryLocationResponse>> Handle(GetFactoryLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.FactoryLocationRepository.GetById(request.FactoryLocationId);
            if (entity == null)
            {
                return new ApiResponse<FactoryLocationResponse>(null, false, "Entity not found");
            }
            var mappedEntity = mapper.Map<FactoryLocation, FactoryLocationResponse>(entity);
            return new ApiResponse<FactoryLocationResponse>(mappedEntity);
        }
    }
}
