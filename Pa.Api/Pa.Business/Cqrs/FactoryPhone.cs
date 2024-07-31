using MediatR;
using Pa.Base.Response;
using Pa.Schema.FactoryPhone;

namespace Pa.Business.Cqrs
{
    public record CreateFactoryPhoneCommand(FactoryPhoneRequest Request): IRequest<ApiResponse<FactoryPhoneResponse>>;
    public record UpdateFactoryPhoneCommand(long FactoryPhoneId, FactoryPhoneRequest Request): IRequest<ApiResponse>;
    public record DeleteFactoryPhoneCommand(long FactoryPhoneId): IRequest<ApiResponse>;

    public record GetAllFactoryPhoneQuery(): IRequest<ApiResponse<List<FactoryPhoneResponse>>>;
    public record GetFactoryPhoneByIdQuery(long FactoryPhoneId) : IRequest<ApiResponse<FactoryPhoneResponse>>;
    public record GetFactoryPhoneByParameterQuery(long? FactoryId, bool? IsPrimary, string? CountryCode) : IRequest<ApiResponse<List<FactoryPhoneResponse>>>;
}
