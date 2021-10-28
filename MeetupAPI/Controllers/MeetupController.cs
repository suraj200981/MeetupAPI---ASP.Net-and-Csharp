using AutoMapper;
using MeetupAPI.Entities;
using MeetupAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;

        private readonly MeetupContext _meetupContext;

        //injecting meetup context (database) through the consturctor 
        public MeetupController(MeetupContext meetupContext, IMapper mapper)
        {
            _meetupContext = meetupContext;
            _mapper = mapper;
        }



        //reterive a list of meetups from our database
        [HttpGet]
        public ActionResult<List<Meetup>> Get() {



            var meetups = _meetupContext.Meetups.Include(m => m.location).ToList();

            var meetupDtos =   _mapper.Map<List<MeetupDetailsDto>>(meetups);

            /*different ways of return status codes*/

            // return NotFound(meetups);
            // return StatusCode(404, meetups);
            // HttpContext.Response.StatusCode = 404;

            return Ok(meetupDtos);
        }
    }
}
