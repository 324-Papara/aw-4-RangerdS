using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryDetail;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pa.Base.Extensions;

namespace Pa.Business.Query.FactoryDetailQuery
{
    public class GetFactoryDetailByParameterQueryHandler : IRequestHandler<GetFactoryDetailByParameterQuery, ApiResponse<List<FactoryDetailResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFactoryDetailByParameterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<FactoryDetailResponse>>> Handle(GetFactoryDetailByParameterQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FactoryDetail, bool>> filter = x => true;

            if (request.FactoryId.HasValue)
            {
                // Filter: FactoryId
                filter = filter.AndAlso(x => x.FactoryId == request.FactoryId);
            }

            var entityList = await unitOfWork.FactoryDetailRepository.GetAll(filter);

            if (!entityList.Any())
            {
                return new ApiResponse<List<FactoryDetailResponse>>(null, false, "Entity not found");
            }

            var mappedList = mapper.Map<List<FactoryDetail>, List<FactoryDetailResponse>>(entityList);
            return new ApiResponse<List<FactoryDetailResponse>>(mappedList);
        }
    }
}