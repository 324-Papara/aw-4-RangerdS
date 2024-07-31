using Pa.Base.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Schema.FactoryDetail
{
    public class FactoryDetailResponse : BaseResponse
    {
        public long FactoryId { get; set;}
        public string FactoryProfile { get; set; }
        public string FactoryHistory { get; set; }
        public string FactoryMission { get; set; }
        public string FactoryVision { get; set; }
        public string FactoryValues { get; set; }
        public string FactoryQualityPolicy { get; set; }
        public string FactoryCertificates { get; set; }
    }
}
