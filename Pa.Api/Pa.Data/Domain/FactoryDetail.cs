using Pa.Base.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pa.Data.Domain
{
    [Table("FactoryDetails", Schema = "dbo")]
    public class FactoryDetail : BaseEntity
    {
        public long FactoryId { get; set; }
        public virtual Factory Factory { get; set; }
        public string FactoryProfile { get; set; }
        public string FactoryHistory { get; set; }
        public string FactoryMission { get; set; }
        public string FactoryVision { get; set; }
        public string FactoryValues { get; set; }
        public string FactoryQualityPolicy { get; set; }
        public string FactoryCertificates { get; set; }
    }
}