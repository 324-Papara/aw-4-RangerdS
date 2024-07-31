using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryLocation;

namespace Pa.Business.Command.FactoryLocationCommand
{
    public class DeleteFactoryLocationCommandHandler : IRequestHandler<DeleteFactoryLocationCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteFactoryLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeleteFactoryLocationCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.FactoryLocationRepository.Delete(request.FactoryLocationId);
            await unitOfWork.Complete();

            return new ApiResponse(true, "Entity successfully deleted");
        }
    }
}
