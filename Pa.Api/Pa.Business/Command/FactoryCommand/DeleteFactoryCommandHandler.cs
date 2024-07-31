using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.Factory;

namespace Pa.Business.Command.FactoryCommand
{
    public class DeleteFactoryCommandHandler : IRequestHandler<DeleteFactoryCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteFactoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeleteFactoryCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.FactoryRepository.Delete(request.FactoryId);
            await unitOfWork.Complete();

            return new ApiResponse(true, "Entity successfully deleted");
        }
    }
}
