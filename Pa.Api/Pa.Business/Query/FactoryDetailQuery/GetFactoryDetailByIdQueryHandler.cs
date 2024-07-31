using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.Query.FactoryDetailQuery
{
    public class GetFactoryDetailByIdQueryHandler : IRequestHandler<GetFactoryDetailByIdQuery, ApiResponse<FactoryDetailResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFactoryDetailByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<FactoryDetailResponse>> Handle(GetFactoryDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.FactoryDetailRepository.GetById(request.FactoryDetailId);
            if (entity == null)
            {
                return new ApiResponse<FactoryDetailResponse>(null, false, "Entity not found");
            }
            var mappedEntity = mapper.Map<FactoryDetail, FactoryDetailResponse>(entity);
            return new ApiResponse<FactoryDetailResponse>(mappedEntity);
        }
    }
}
