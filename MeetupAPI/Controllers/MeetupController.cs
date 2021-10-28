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


        [HttpGet("{str}")]
        public ActionResult<MeetupDetailsDto> Get(string str) {


            /*  getting meet up data and including location, then using FirstOfDeafult to return 
             * first element in the database which is == to input value */

            var meetup = _meetupContext.Meetups.Include(m => m.location)
                .FirstOrDefault(m => m.name.ToLower().Replace(" ", "-") == str.ToLower());

            if (meetup == null) {

                return NotFound();
            }

            var meetupDto = _mapper.Map<MeetupDetailsDto>(meetup);
            
            return Ok(meetupDto);

        }



        [HttpPost]
        public ActionResult Post([FromBody]MeetupDto model) {

            var meetup = _mapper.Map<Meetup>(model);

            _meetupContext.Meetups.Add(meetup);
            _meetupContext.SaveChanges();

            //puts the newly created name in the url
            var key = meetup.name.Replace(" ", "-").ToLower();

            return Created("api/meetup/" + key, null);

        }


    }
}
