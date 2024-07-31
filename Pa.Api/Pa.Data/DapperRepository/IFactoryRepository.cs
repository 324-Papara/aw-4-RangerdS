using Pa.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Data.DapperRepository
{
    public interface IFactoryRepository
    {
        Task<IEnumerable<Factory>> GetCustomersWithDetails();
    }
}
