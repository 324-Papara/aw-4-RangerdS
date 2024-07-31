using MediatR;
using Pa.Base.Response;
using Pa.Schema.FactoryDetail;

namespace Pa.Business.Cqrs
{
    public record CreateFactoryDetailCommand(FactoryDetailRequest Request): IRequest<ApiResponse<FactoryDetailResponse>>;
    public record UpdateFactoryDetailCommand(long FactoryDetailId, FactoryDetailRequest Request): IRequest<ApiResponse>;
    public record DeleteFactoryDetailCommand(long FactoryDetailId): IRequest<ApiResponse>;

    public record GetAllFactoryDetailQuery(): IRequest<ApiResponse<List<FactoryDetailResponse>>>;
    public record GetFactoryDetailByIdQuery(long FactoryDetailId) : IRequest<ApiResponse<FactoryDetailResponse>>;
    public record GetFactoryDetailByParameterQuery(long? FactoryId) : IRequest<ApiResponse<List<FactoryDetailResponse>>>;
}
