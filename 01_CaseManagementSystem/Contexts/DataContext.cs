using _01_CaseManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_CaseManagementSystem.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Skola\Databases\01_CaseManagementSystem\01_CaseManagementSystem\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion

        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        #endregion

        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<TenantEntity> Tenants { get; set; } = null!;
        public DbSet<ErrorEntity> Errors { get; set; } = null!;
        public DbSet<CommentEntity> Comments { get; set; }

    }
}
