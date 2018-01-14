using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid? SessionId { get; set; }
        public DateTime? SessionExpireDate { get; set; }
        public DateTime? LastLoginTs { get; set; }
    }
}