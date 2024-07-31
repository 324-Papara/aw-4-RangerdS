using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryPhone;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pa.Base.Extensions;

namespace Pa.Business.Query.FactoryPhoneQuery
{
    public class GetFactoryPhoneByParameterQueryHandler : IRequestHandler<GetFactoryPhoneByParameterQuery, ApiResponse<List<FactoryPhoneResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFactoryPhoneByParameterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<FactoryPhoneResponse>>> Handle(GetFactoryPhoneByParameterQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FactoryPhone, bool>> filter = x => true;

            if (request.FactoryId.HasValue)
            {
                // Filter: FactoryId
                filter = filter.AndAlso(x => x.FactoryId == request.FactoryId);
            }

            if (request.IsPrimary.HasValue)
            {
                // Filter: IsPrimary
                filter = filter.AndAlso(x => x.IsPrimary == request.IsPrimary);
            }

            if (!string.IsNullOrEmpty(request.CountryCode))
            {
                // Filter: CountryCode
                filter = filter.AndAlso(x => x.CountryCode.ToLower().Contains(request.CountryCode.ToLower()));
            }

            var entityList = await unitOfWork.FactoryPhoneRepository.GetAll(filter);

            if (!entityList.Any())
            {
                return new ApiResponse<List<FactoryPhoneResponse>>(null, false, "Entity not found");
            }

            var mappedList = mapper.Map<List<FactoryPhone>, List<FactoryPhoneResponse>>(entityList);
            return new ApiResponse<List<FactoryPhoneResponse>>(mappedList);
        }
    }
}
