using Pa.Base.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pa.Data.Domain
{
    [Table("FactoryPhones", Schema = "dbo")]
    public class FactoryPhone : BaseEntity
    {
        public long FactoryId { get; set; }
        public virtual Factory Factory { get; set; }
        public bool IsPrimary { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
