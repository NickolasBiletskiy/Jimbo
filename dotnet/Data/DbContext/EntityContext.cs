
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Entities;

namespace Data.DbContext
{
    public class EntityContext : System.Data.Entity.DbContext
    {
        public EntityContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #region DbSet

        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Message> Message { get; set; }

        #endregion
    }
}
