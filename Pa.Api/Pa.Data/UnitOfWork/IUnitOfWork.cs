using Pa.Data.Domain;
using Pa.Data.GenericRepository;

namespace Pa.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Complete();
        Task CompleteWithTran();

        IGenericRepository<Factory> FactoryRepository { get; }
        IGenericRepository<FactoryDetail> FactoryDetailRepository { get; }
        IGenericRepository<FactoryLocation> FactoryLocationRepository { get; }
        IGenericRepository<FactoryPhone> FactoryPhoneRepository { get; }
    }
}
