using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryLocation; 

namespace Pa.Business.Command.FactoryLocationCommand
{
    public class UpdateFactoryLocationCommandHandler : IRequestHandler<UpdateFactoryLocationCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateFactoryLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateFactoryLocationCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<FactoryLocationRequest, FactoryLocation>(request.Request);
            await unitOfWork.FactoryLocationRepository.Update(request.FactoryLocationId, mappedEntity);
            await unitOfWork.Complete();

            return new ApiResponse(true, "Entity successfully updated");
        }
    }
}
