using Pa.Base.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Schema.FactoryPhone
{
    public class FactoryPhoneResponse : BaseResponse
    {
        public long FactoryId { get; set; }
        public bool IsPrimary { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
