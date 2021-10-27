using MeetupAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI
{
    public class MeetupDataSeeder
    {

        //connection to database through constructor 
        private readonly MeetupContext _meetupContext;
        public MeetupDataSeeder(MeetupContext meetupContext)
        {
            _meetupContext = meetupContext;
        }


        //1. we want to check if we can connect to the database
        //2. we then want to check if the meetup table is empty, if it is not then we can seed with data
        public void Seed() {

            if (_meetupContext.Database.CanConnect()) {

                if (!_meetupContext.Meetups.Any()) {
                    InsertSampleData();
                }

            }


        }

        private void InsertSampleData()
        {
            var meetups = new List<Meetup> {
                new Meetup {
                name = "Web Summit",
                date = DateTime.Now.AddDays(7),
                IsPrivate = false,
                organiser = "Microsoft",
                location = new Location {

                    City = "Krakow",
                    Street = "Szeroka 33/5",
                    PostCode = "31-337"
                },
                Lectures = new List<Lecture>
                {
                    new Lecture
                        {
                        Author = "Bob Clark",
                        Subject = "Modern browsers",
                        Description = "Deep dive into v8"

                        }
                    }
                 },

                new Meetup {
                name = "West park",
                date = DateTime.Now.AddDays(7),
                IsPrivate = true,
                organiser = "Apple",
                location = new Location {

                    City = "Nottingham",
                    Street = "Wilsthorpe Road",
                    PostCode = "ng104aa"
                },
                Lectures = new List<Lecture>
                {
                    new Lecture
                        {
                        Author = "Jason Nurse",
                        Subject = "Cyber Security",
                        Description = "AB101"

                        },
                    new Lecture
                        {
                        Author = "David Barns",
                        Subject = "Intro to OOP",
                        Description = "OOP101"

                        }
                    }
                 },
            };

            _meetupContext.AddRange(meetups);
            _meetupContext.SaveChanges();
        }
    }
}
