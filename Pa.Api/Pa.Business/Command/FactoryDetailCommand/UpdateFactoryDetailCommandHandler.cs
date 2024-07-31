using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryDetail;

namespace Pa.Business.Command.FactoryDetailCommand
{
    public class UpdateFactoryDetailCommandHandler : IRequestHandler<UpdateFactoryDetailCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateFactoryDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateFactoryDetailCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<FactoryDetailRequest, FactoryDetail>(request.Request);
            await unitOfWork.FactoryDetailRepository.Update(request.FactoryDetailId, mappedEntity);
            await unitOfWork.Complete();

            return new ApiResponse(true, "Entity successfully updated");
        }
    }
}
