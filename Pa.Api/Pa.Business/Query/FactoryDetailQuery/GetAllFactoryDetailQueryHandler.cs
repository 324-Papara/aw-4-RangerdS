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
    public class GetAllFactoryDetailQueryHandler : IRequestHandler<GetAllFactoryDetailQuery, ApiResponse<List<FactoryDetailResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllFactoryDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<FactoryDetailResponse>>> Handle(GetAllFactoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entityList = await unitOfWork.FactoryDetailRepository.GetAll();
            if (!entityList.Any())
            {
                return new ApiResponse<List<FactoryDetailResponse>>(null, false, "Entity not found");
            }
            var mappedList = mapper.Map<List<FactoryDetail>, List<FactoryDetailResponse>>(entityList);
            return new ApiResponse<List<FactoryDetailResponse>>(mappedList);
        }
    }
}
