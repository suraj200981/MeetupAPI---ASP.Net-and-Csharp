using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI.Entities
{
    public class MeetupContext : DbContext
    {

        //connection string
        public string connectionString = "Server=DESKTOP-T26JVFF;Database=MeetupDb;Trusted_Connection=True;MultipleActiveResultSets=True";

        /*these 3 db sets will represent tables from our database*/
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        //create relationships beetween the entities 

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //meet up entity has one location, here I am defineing that relationship through entity framework 
            modelBuilder.Entity<Meetup>().HasOne(m => m.location)
                .WithOne(l => l.Meetup)
                .HasForeignKey<Location>(l => l.MeetupId);

            //meet up entity has many lectures
            modelBuilder.Entity<Meetup>()
                .HasMany(m => m.Lectures)
                .WithOne(l => l.Meetup);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
