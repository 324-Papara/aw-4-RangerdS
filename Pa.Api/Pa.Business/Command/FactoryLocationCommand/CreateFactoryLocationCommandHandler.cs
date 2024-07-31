using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryLocation;

namespace Pa.Business.Command.FactoryLocationCommand
{
    public class CreateFactoryLocationCommandHandler : IRequestHandler<CreateFactoryLocationCommand, ApiResponse<FactoryLocationResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateFactoryLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<FactoryLocationResponse>> Handle(CreateFactoryLocationCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<FactoryLocationRequest, FactoryLocation>(request.Request);
            await unitOfWork.FactoryLocationRepository.Insert(mappedEntity);
            await unitOfWork.Complete();


            var response = mapper.Map<FactoryLocationResponse>(mappedEntity);
            return new ApiResponse<FactoryLocationResponse>(response, true, "Entity successfully created");
        }
    }
}
