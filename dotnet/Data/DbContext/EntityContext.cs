
using System.Data.Entity;
using Data.Entities;

namespace Data.DbContext
{
    public class EntityContext : System.Data.Entity.DbContext
    {
        public EntityContext() : base("DefaultConnection")
        {
            
        }

        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }

        #endregion
    }
}
