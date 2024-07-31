using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.Command.FactoryCommand
{
    public class UpdateFactoryCommandHandler : IRequestHandler<UpdateFactoryCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateFactoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateFactoryCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<FactoryRequest, Factory>(request.Request);
            await unitOfWork.FactoryRepository.Update(request.FactoryId, mappedEntity);
            await unitOfWork.Complete();

            return new ApiResponse(true, "Entity successfully updated");
        }
    }
}
