namespace Pa.Base.Entity
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public long CreateUserId { get; set; }
        public long UpdateUserId { get; set; }
        public long DeleteUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
