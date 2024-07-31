using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryLocation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pa.Base.Extensions;

namespace Pa.Business.Query.FactoryLocationQuery
{
    public class GetFactoryLocationByParameterQueryHandler : IRequestHandler<GetFactoryLocationByParameterQuery, ApiResponse<List<FactoryLocationResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFactoryLocationByParameterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<FactoryLocationResponse>>> Handle(GetFactoryLocationByParameterQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FactoryLocation, bool>> filter = x => true;

            if (!string.IsNullOrEmpty(request.FactoryLocationName))
            {
                // Filter: FactoryLocationName
                filter = filter.AndAlso(x => x.LocationName.ToLower().Contains(request.FactoryLocationName.ToLower()));
            }

            var entityList = await unitOfWork.FactoryLocationRepository.GetAll(filter);

            if (!entityList.Any())
            {
                return new ApiResponse<List<FactoryLocationResponse>>(null, false, "Entity not found");
            }

            var mappedList = mapper.Map<List<FactoryLocation>, List<FactoryLocationResponse>>(entityList);
            return new ApiResponse<List<FactoryLocationResponse>>(mappedList);
        }
    }
}
