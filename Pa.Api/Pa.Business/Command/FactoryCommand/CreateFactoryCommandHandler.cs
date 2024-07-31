using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.Factory;

namespace Pa.Business.Command.FactoryCommand
{
    public class CreateFactoryCommandHandler : IRequestHandler<CreateFactoryCommand, ApiResponse<FactoryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateFactoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<FactoryResponse>> Handle(CreateFactoryCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<FactoryRequest, Factory>(request.Request);
            await unitOfWork.FactoryRepository.Insert(mappedEntity);
            await unitOfWork.Complete();

            var response = mapper.Map<FactoryResponse>(mappedEntity);
            return new ApiResponse<FactoryResponse>(response, true, "Entity successfully created");
        }
    }
}
