using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.Query.FactoryQuery
{
    public class GetFactoryByIdQueryHandler : IRequestHandler<GetFactoryByIdQuery, ApiResponse<FactoryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFactoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<FactoryResponse>> Handle(GetFactoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.FactoryRepository.GetById(request.FactoryId);
            if (entity == null)
            {
                return new ApiResponse<FactoryResponse>(null, false, "Entity not found");
            }
            var mappedEntity = mapper.Map<Factory, FactoryResponse>(entity);
            return new ApiResponse<FactoryResponse>(mappedEntity);
        }
    }
}
