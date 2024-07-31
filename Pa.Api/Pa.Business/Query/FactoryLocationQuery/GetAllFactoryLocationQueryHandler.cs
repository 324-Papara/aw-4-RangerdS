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
    public class GetAllFactoryLocationQueryHandler : IRequestHandler<GetAllFactoryLocationQuery, ApiResponse<List<FactoryLocationResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllFactoryLocationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<FactoryLocationResponse>>> Handle(GetAllFactoryLocationQuery request, CancellationToken cancellationToken)
        {
            var entityList = await unitOfWork.FactoryLocationRepository.GetAll();
            if (!entityList.Any())
            {
                return new ApiResponse<List<FactoryLocationResponse>>(null, false, "Entity not found");
            }
            var mappedList = mapper.Map<List<FactoryLocation>, List<FactoryLocationResponse>>(entityList);
            return new ApiResponse<List<FactoryLocationResponse>>(mappedList);
        }
    }
}
