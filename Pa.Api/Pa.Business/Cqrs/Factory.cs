using MediatR;
using Pa.Base.Response;
using Pa.Schema.Factory;

namespace Pa.Business.Cqrs
{
    public record CreateFactoryCommand(FactoryRequest Request): IRequest<ApiResponse<FactoryResponse>>;
    public record UpdateFactoryCommand(long FactoryId, FactoryRequest Request): IRequest<ApiResponse>;
    public record DeleteFactoryCommand(long FactoryId): IRequest<ApiResponse>;

    public record GetAllFactoryQuery(): IRequest<ApiResponse<List<FactoryResponse>>>;
    public record GetFactoryByIdQuery(long FactoryId) : IRequest<ApiResponse<FactoryResponse>>;
    public record GetFactoryByParameterQuery(long? FactoryId , string? FactoryName, int? Capacity) : IRequest<ApiResponse<List<FactoryResponse>>>;
}
