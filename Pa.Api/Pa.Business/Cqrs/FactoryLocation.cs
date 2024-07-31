using MediatR;
using Pa.Base.Response;
using Pa.Schema.FactoryLocation;

namespace Pa.Business.Cqrs
{
    public record CreateFactoryLocationCommand(FactoryLocationRequest Request): IRequest<ApiResponse<FactoryLocationResponse>>;
    public record UpdateFactoryLocationCommand(long FactoryLocationId, FactoryLocationRequest Request): IRequest<ApiResponse>;
    public record DeleteFactoryLocationCommand(long FactoryLocationId): IRequest<ApiResponse>;

    public record GetAllFactoryLocationQuery(): IRequest<ApiResponse<List<FactoryLocationResponse>>>;
    public record GetFactoryLocationByIdQuery(long FactoryLocationId) : IRequest<ApiResponse<FactoryLocationResponse>>;
    public record GetFactoryLocationByParameterQuery(string? FactoryLocationName) : IRequest<ApiResponse<List<FactoryLocationResponse>>>;
}
