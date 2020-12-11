using System;

namespace YVN.Models.Abstract
{
    public abstract class Entity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime EditedOn { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedOn { get; set; }
    }
}
