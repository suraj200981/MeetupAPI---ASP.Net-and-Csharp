using MeetupAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI.Controllers
{

    //establishing endpoint for this controller
    [Route("api/meetup")]
    public class MeetupController : ControllerBase
    {
        private MeetupContext _meetupContext { get; }

        //injecting meetup context (database) through the consturctor 
        public MeetupController(MeetupContext meetupContext)
        {
            _meetupContext = meetupContext;
        }



        //reterive a list of meetups from our database
        [HttpGet]
        public ActionResult<List<Meetup>> Get() {



            var meetups = _meetupContext.Meetups.ToList();


            /*different ways of return status codes*/

            // return NotFound(meetups);
            // return StatusCode(404, meetups);
            // HttpContext.Response.StatusCode = 404;

            return Ok(meetups);
        }
    }
}
