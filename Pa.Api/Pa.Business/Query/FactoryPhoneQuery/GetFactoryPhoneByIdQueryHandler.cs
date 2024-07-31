using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.Query.FactoryPhoneQuery
{
    public class GetFactoryPhoneByIdQueryHandler : IRequestHandler<GetFactoryPhoneByIdQuery, ApiResponse<FactoryPhoneResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFactoryPhoneByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<FactoryPhoneResponse>> Handle(GetFactoryPhoneByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.FactoryPhoneRepository.GetById(request.FactoryPhoneId);
            if (entity == null)
            {
                return new ApiResponse<FactoryPhoneResponse>(null, false, "Entity not found");
            }
            var mappedEntity = mapper.Map<FactoryPhone, FactoryPhoneResponse>(entity);
            return new ApiResponse<FactoryPhoneResponse>(mappedEntity);
        }
    }
}
