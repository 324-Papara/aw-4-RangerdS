using Pa.Base.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pa.Data.Domain
{
    [Table("Factories", Schema = "dbo")]
    public class Factory : BaseEntity
    {
        public required string FactoryName { get; set; }
        public int Capacity { get; set; }
        public int EmployeeCount { get; set; }
        public DateTime EstablishedDate { get; set; }
        public required string Email { get; set; }
        public required string TaxNumber { get; set; }

        public virtual FactoryDetail? FactoryDetail { get; set; }
        public virtual List<FactoryLocation>? FactoryLocations { get; set; }
        public virtual List<FactoryPhone>? FactoryPhones { get; set; }
        
    }
}
