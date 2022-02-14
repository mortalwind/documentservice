
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace DocumentMono.DataAccess
{
    public class DocumentDbContext: DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<CivilServant> CivilServants { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<FlowStep> FlowSteps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=root;password=31Ocak1983");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ForMySQLHasCollation("latin5_turkish_ci");
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<CivilServant>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ForMySQLHasCollation("latin5_turkish_ci");
                entity.Property(e => e.ServantName).IsRequired();
                entity.Property(e => e.ServantLastName).IsRequired();
                entity.Property(e => e.ManagerID).IsRequired();
                entity.HasOne(d => d.User);
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ForMySQLHasCollation("latin5_turkish_ci");
                entity.Property(e => e.IdentityNumber).IsRequired();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ForMySQLHasCollation("latin5_turkish_ci");
                entity.Property(e => e.FileName).IsRequired();
                entity.Property(e => e.FileContent).IsRequired();
                entity.Property(e => e.DateCreated).IsRequired();
                entity.HasOne(c => c.Citizen).WithMany(m => m.Documents);
            });

            modelBuilder.Entity<FlowStep>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.DocumentID });
                entity.Property(e => e.FlowStatus).IsRequired();

            });
        }
    }
}
