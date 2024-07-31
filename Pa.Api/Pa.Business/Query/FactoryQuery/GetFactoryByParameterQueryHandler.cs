using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.Factory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pa.Base.Extensions;

namespace Pa.Business.Query.FactoryQuery
{
    public class GetFactoryByParameterQueryHandler : IRequestHandler<GetFactoryByParameterQuery, ApiResponse<List<FactoryResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFactoryByParameterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<FactoryResponse>>> Handle(GetFactoryByParameterQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Factory, bool>> filter = x => true;

            if (!string.IsNullOrEmpty(request.FactoryName))
            {
                // Filter: FactoryName
                filter = filter.AndAlso(x => x.FactoryName.ToLower().Contains(request.FactoryName.ToLower()));
            }

            if (request.Capacity.HasValue)
            {
                // Filter: Capacity
                filter = filter.AndAlso(x => x.Capacity == request.Capacity);
            }

            var entityList = await unitOfWork.FactoryRepository.GetAll(filter);

            if (!entityList.Any())
            {
                return new ApiResponse<List<FactoryResponse>>(null, false, "Entity not found");
            }

            var mappedList = mapper.Map<List<Factory>, List<FactoryResponse>>(entityList);
            return new ApiResponse<List<FactoryResponse>>(mappedList);
        }
    }
}
