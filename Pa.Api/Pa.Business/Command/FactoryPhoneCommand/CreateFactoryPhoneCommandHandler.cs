using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryPhone;

namespace Pa.Business.Command.FactoryPhoneCommand
{
    public class CreateFactoryPhoneCommandHandler : IRequestHandler<CreateFactoryPhoneCommand, ApiResponse<FactoryPhoneResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateFactoryPhoneCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<FactoryPhoneResponse>> Handle(CreateFactoryPhoneCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<FactoryPhoneRequest, FactoryPhone>(request.Request);
            await unitOfWork.FactoryPhoneRepository.Insert(mappedEntity);
            await unitOfWork.Complete();

            var response = mapper.Map<FactoryPhoneResponse>(mappedEntity);
            return new ApiResponse<FactoryPhoneResponse>(response, true, "Entity successfully created");
        }
    }
}
