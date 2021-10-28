using MeetupAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI.Models
{
    //'Dto' means data transfer object, which is the object that will be used to exchange information 
    public class MeetupDetailsDto
    {
        //meetup
        public string name { get; set; }
        public string organiser { get; set; }
        public DateTime date { get; set; }
        public bool IsPrivate { get; set; }


        //location
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }



        //automapper
    }
}
