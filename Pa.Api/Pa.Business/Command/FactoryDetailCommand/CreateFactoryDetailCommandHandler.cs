using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.Factory;
using Pa.Schema.FactoryDetail;

namespace Pa.Business.Command.FactoryDetailCommand
{
    public class CreateFactoryDetailCommandHandler : IRequestHandler<CreateFactoryDetailCommand, ApiResponse<FactoryDetailResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateFactoryDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<FactoryDetailResponse>> Handle(CreateFactoryDetailCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<FactoryDetailRequest, FactoryDetail>(request.Request);
            await unitOfWork.FactoryDetailRepository.Insert(mappedEntity);
            await unitOfWork.Complete();

            var response = mapper.Map<FactoryDetailResponse>(mappedEntity);
            return new ApiResponse<FactoryDetailResponse>(response, true, "Entity successfully created");
        }
    }
}
