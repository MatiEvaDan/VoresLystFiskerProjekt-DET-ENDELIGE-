using Lystfiskerportalen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace VoresLystFiskerPortal.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<TechniqueEquipment> TechniqueEquipment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Posts");

                entity.HasOne(p => p.User)
                      .WithMany(u => u.Posts)
                      .HasForeignKey(p => p.UserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Fish>(entity =>
            {
                entity.ToTable("Fish");
              
            });

            modelBuilder.Entity<TechniqueEquipment>(entity =>
            {
                entity.ToTable("TechniqueEquipment");
               
            });

        }
    }
}
           

