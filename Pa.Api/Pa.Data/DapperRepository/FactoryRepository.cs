using Dapper;
using Pa.Data.Domain;
using System.Data;

namespace Pa.Data.DapperRepository
{
    public class FactoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public FactoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Factory>> GetFactoriesWithDetailsAsync()
        {
            var sql = @"
            SELECT * FROM Factories;
            SELECT * FROM FactoryDetails WHERE FactoryId IN (SELECT Id FROM Factories);
            SELECT * FROM FactoryLocations WHERE FactoryId IN (SELECT Id FROM Factories);
            SELECT * FROM FactoryPhones WHERE FactoryId IN (SELECT Id FROM Factories);";

            using (var multi = await _dbConnection.QueryMultipleAsync(sql))
            {
                var factories = multi.Read<Factory>().ToList();
                var factoryDetails = multi.Read<FactoryDetail>().ToList();
                var factoryLocations = multi.Read<FactoryLocation>().ToList();
                var factoryPhones = multi.Read<FactoryPhone>().ToList();

                foreach (var factory in factories)
                {
                    factory.FactoryDetail = factoryDetails.FirstOrDefault(fd => fd.FactoryId == factory.Id);
                    factory.FactoryLocations = factoryLocations.Where(fl => fl.FactoryId == factory.Id).ToList();
                    factory.FactoryPhones = factoryPhones.Where(fp => fp.FactoryId == factory.Id).ToList();
                }

                return factories;
            }
        }
    }
}
