using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Contact : BaseEntity
    {
        [Key]
        public Guid ContactId { get; set; }
        public Guid HostUserId { get; set; }
        public Guid ContactUserId { get; set; }

        public virtual User HostUser { get; set; }
        public virtual User ContactUser { get; set; }
    }
}