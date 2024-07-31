using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryPhone;

namespace Pa.Business.Command.FactoryPhoneCommand
{
    public class DeleteFactoryPhoneCommandHandler : IRequestHandler<DeleteFactoryPhoneCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteFactoryPhoneCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeleteFactoryPhoneCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.FactoryPhoneRepository.Delete(request.FactoryPhoneId);
            await unitOfWork.Complete();

            return new ApiResponse(true, "Entity successfully deleted");
        }
    }
}
