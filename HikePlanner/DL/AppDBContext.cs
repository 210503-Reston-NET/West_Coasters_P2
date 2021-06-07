using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions options) : base(options)
        { }
        protected AppDBContext()
        { }

        /// <summary>
        /// Declaring entities
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .Property(user => user.UserId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Equipment>()
            .Property(equipment => equipment.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Checklist>()
            .Property(checklist => checklist.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<ChecklistItem>()
            .Property(checklistItem => checklistItem.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Address>()
            .Property(address => address.Id)
            .ValueGeneratedOnAdd();
        }
    }
}