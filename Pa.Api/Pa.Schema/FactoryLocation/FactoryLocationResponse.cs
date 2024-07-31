using Pa.Base.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Schema.FactoryLocation
{
    public class FactoryLocationResponse : BaseResponse
    {
        public long FactoryId { get; set; }
        public required string LocationName { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string District { get; set; }
        public required string Address { get; set; }
        public required string PostalCode { get; set; }
    }
}
