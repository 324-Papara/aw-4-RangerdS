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
    public class GetAllFactoryPhoneQueryHandler : IRequestHandler<GetAllFactoryPhoneQuery, ApiResponse<List<FactoryPhoneResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllFactoryPhoneQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<FactoryPhoneResponse>>> Handle(GetAllFactoryPhoneQuery request, CancellationToken cancellationToken)
        {
            var entityList = await unitOfWork.FactoryPhoneRepository.GetAll();
            if (!entityList.Any())
            {
                return new ApiResponse<List<FactoryPhoneResponse>>(null, false, "Entity not found");
            }
            var mappedList = mapper.Map<List<FactoryPhone>, List<FactoryPhoneResponse>>(entityList);
            return new ApiResponse<List<FactoryPhoneResponse>>(mappedList);
        }
    }
}
