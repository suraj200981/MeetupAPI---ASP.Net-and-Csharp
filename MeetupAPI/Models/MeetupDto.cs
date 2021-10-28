using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI.Models
{
    public class MeetupDto
    {

        public string name { get; set; }
        public string organiser { get; set; }
        public DateTime date { get; set; }
        public bool IsPrivate { get; set; }
    }
}
