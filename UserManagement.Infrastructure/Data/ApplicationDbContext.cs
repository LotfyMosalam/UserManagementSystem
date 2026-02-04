using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Username)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(x => x.Password)
                      .IsRequired();

                entity.Property(x => x.UserFullName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(x => x.IsActive)
                      .IsRequired();

                entity.Property(x => x.DateOfBirth)
                      .IsRequired();

                entity.Property(x => x.CreationDate)
                      .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
