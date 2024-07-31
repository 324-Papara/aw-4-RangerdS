using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryDetail;

namespace Pa.Business.Command.FactoryDetailCommand
{
    public class DeleteFactoryDetailCommandHandler : IRequestHandler<DeleteFactoryDetailCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteFactoryDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeleteFactoryDetailCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.FactoryDetailRepository.Delete(request.FactoryDetailId);
            await unitOfWork.Complete();

            return new ApiResponse(true, "Entity successfully deleted");
        }
    }
}
