using Microsoft.EntityFrameworkCore;
using IntelliCRMAPIService.DBContext.DBEntities;

namespace IntelliCRMAPIService.DBContext
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres; Password=admin@123; Port=5432");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");
        }

        public virtual DbSet<Apiusers> Apiusers { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}