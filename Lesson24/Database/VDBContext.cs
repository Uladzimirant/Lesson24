using Lesson24.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson24.Database
{
    public class VDBContext : DbContext
    {
        public VDBContext(DbContextOptions opts) : base(opts)
        {
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ent =>
            {
                ent.ToTable("User");
                ent.HasKey(ent => ent.Id);

                ent.Property(e => e.Id).ValueGeneratedNever();
                ent.Property(e => e.Login)
                .HasMaxLength(40)
                .IsRequired();

                ent.HasMany(u => u.Tokens).WithOne(t => t.User)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Token>(ent =>
            {
                ent.ToTable("Token");
                ent.HasKey(ent => ent.Id);

                ent.Property(e => e.Id).ValueGeneratedNever();
                ent.Property(e => e.Value)
                .IsRequired();
            });
        }
    }
}
