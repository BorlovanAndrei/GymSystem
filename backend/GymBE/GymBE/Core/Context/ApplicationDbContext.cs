using GymBE.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymBE.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Membership> Memberships { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Membership)
                .WithMany(membership => membership.Users)
                .HasForeignKey(user => user.MembershipId);

            //modelBuilder.Entity<Equipment>()
            //    .Property(e => e.Price)
            //    .HasColumnType("decimal(18, 2)");

            //modelBuilder.Entity<Membership>()
            //    .Property(e => e.Price)
            //    .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Equipment>()
                .Property(equipment => equipment.Type)
                .HasConversion<string>();
        }

    }
}
