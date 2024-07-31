using AutoMapper;
using MediatR;
using Pa.Base.Response;
using Pa.Business.Cqrs;
using Pa.Data.Domain;
using Pa.Data.UnitOfWork;
using Pa.Schema.FactoryPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.Command.FactoryPhoneCommand
{
    public class UpdateFactoryPhoneCommandHandler : IRequestHandler<UpdateFactoryPhoneCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateFactoryPhoneCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateFactoryPhoneCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<FactoryPhoneRequest, FactoryPhone>(request.Request);
            await unitOfWork.FactoryPhoneRepository.Update(request.FactoryPhoneId, mappedEntity);
            await unitOfWork.Complete();

            return new ApiResponse(true, "Entity successfully updated");
        }
    }
}
