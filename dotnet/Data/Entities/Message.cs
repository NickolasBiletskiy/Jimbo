using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Message : BaseEntity
    {
        [Key]
        public Guid MessageId { get; set; }
        public Guid UserFromId { get; set; }
        public Guid UserToId { get; set; }
        public string MessageText { get; set; }
        public DateTime SentTS { get; set; }
        public DateTime LastSyncBySenderTS { get; set; }
        public DateTime LastSyncByReceiverTS { get; set; }

        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
    }
}