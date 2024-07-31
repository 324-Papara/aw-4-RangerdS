using Pa.Base.Entity;
using System.ComponentModel.DataAnnotations.Schema;
namespace Pa.Data.Domain
{
    [Table("FactoryLocations", Schema = "dbo")]
    public class FactoryLocation : BaseEntity
    {
        public long FactoryId { get; set; }
        public virtual Factory Factory { get; set; }
        public required string LocationName { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string District { get; set; }
        public required string Address { get; set; }
        public required string PostalCode { get; set; }
    }
}
