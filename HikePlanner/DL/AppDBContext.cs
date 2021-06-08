using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base()
        { }

        public AppDBContext(DbContextOptions options) : base(options)
        { }

        /// <summary>
        /// Declaring entities
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Participant> Participants { get; set; }

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

            modelBuilder.Entity<Trip>()
            .Property(trip => trip.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Activity>()
            .Property(activity => activity.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Post>()
            .Property(post => post.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Participant>()
            .Property(participant => participant.Id)
            .ValueGeneratedOnAdd();
        }
    }
}

/*
CLI:
dotnet ef migrations add update_activity_post -c AppDBContext --startup-project ../WebAPI
dotnet ef database update --startup-project ../WebAPI
*/