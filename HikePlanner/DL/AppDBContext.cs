using Microsoft.EntityFrameworkCore;
using Models;
namespace DL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base()
        {}
        public AppDBContext(DbContextOptions options) : base(options)
        {}

        /// <summary>
        /// Declaring entities
        /// </summary>
        public DbSet<User> Users { get; set; }

        public DbSet<Equipment> Equipments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .Property(user => user.UserId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Equipment>()
            .Property(equipment => equipment.Id)
            .ValueGeneratedOnAdd();
        }
    }
}