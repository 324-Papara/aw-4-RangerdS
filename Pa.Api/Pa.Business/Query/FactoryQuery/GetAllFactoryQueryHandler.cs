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
    public class GetAllFactoryQueryHandler : IRequestHandler<GetAllFactoryQuery, ApiResponse<List<FactoryResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllFactoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<FactoryResponse>>> Handle(GetAllFactoryQuery request, CancellationToken cancellationToken)
        {
            var entityList = await unitOfWork.FactoryRepository.GetAll();
            if (!entityList.Any())
            {
                return new ApiResponse<List<FactoryResponse>>(null, false, "Entity not found");
            }
            var mappedList = mapper.Map<List<Factory>, List<FactoryResponse>>(entityList);
            return new ApiResponse<List<FactoryResponse>>(mappedList);
        }
    }
}
