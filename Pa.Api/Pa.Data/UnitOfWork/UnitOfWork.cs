using Pa.Data.Context;
using Pa.Data.Domain;
using Pa.Data.GenericRepository;

namespace Pa.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaMsDbContext _msContext;

        public IGenericRepository<Factory> FactoryRepository { get; }
        public IGenericRepository<FactoryDetail> FactoryDetailRepository { get; }
        public IGenericRepository<FactoryLocation> FactoryLocationRepository { get; }
        public IGenericRepository<FactoryPhone> FactoryPhoneRepository { get; }

        public UnitOfWork(PaMsDbContext msContext)
        {
            this._msContext = msContext;

            FactoryRepository = new GenericRepository<Factory>(msContext);
            FactoryDetailRepository = new GenericRepository<FactoryDetail>(msContext);
            FactoryLocationRepository = new GenericRepository<FactoryLocation>(msContext);
            FactoryPhoneRepository = new GenericRepository<FactoryPhone>(msContext);
        }

        public async Task Complete()
        {
            await _msContext.SaveChangesAsync();
        }

        public async Task CompleteWithTran()
        {
            using (var dbTransaction = await _msContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _msContext.SaveChangesAsync();
                    await dbTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbTransaction.RollbackAsync();
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public void Dispose()
        {
            return;
        }
    }
}
