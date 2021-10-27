using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI.Entities
{
    public class Meetup
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string organiser { get; set; }
        public DateTime date { get; set; }
        public bool IsPrivate { get; set; }
        public virtual Location location { get; set; }
        public virtual List<Lecture> Lectures { get; set; }

    }
}
