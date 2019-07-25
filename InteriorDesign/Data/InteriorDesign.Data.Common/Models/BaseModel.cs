namespace InteriorDesign.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }
    }
}
