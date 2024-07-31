using Pa.Base.Schema;

namespace Pa.Schema.Factory
{
    public class FactoryRequest : BaseRequest
    {
        public required string FactoryName { get; set; }
        public int Capacity { get; set; }
        public int EmployeeCount { get; set; }
        public DateTime EstablishedDate { get; set; }
        public required string Email { get; set; }
        public required string TaxNumber { get; set; }
    }
}
