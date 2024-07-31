using Pa.Base.Schema;

namespace Pa.Schema.FactoryDetail
{
    public class FactoryDetailRequest : BaseRequest
    {
        public long FactoryId { get; set; }
        public string FactoryProfile { get; set; }
        public string FactoryHistory { get; set; }
        public string FactoryMission { get; set; }
        public string FactoryVision { get; set; }
        public string FactoryValues { get; set; }
        public string FactoryQualityPolicy { get; set; }
        public string FactoryCertificates { get; set; }
    }
}
