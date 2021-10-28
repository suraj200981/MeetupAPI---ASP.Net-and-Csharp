using AutoMapper;
using MeetupAPI.Entities;
using MeetupAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI
{
    //extend to profile which is in automapper
    public class MeetupProfile : Profile
    {

        public MeetupProfile()
        {

            /*Automapper*/
            CreateMap<Meetup, MeetupDetailsDto>()
                .ForMember(m => m.City, map => map.MapFrom(l => l.location.City))
                .ForMember(m => m.PostCode, map => map.MapFrom(l => l.location.PostCode))
                .ForMember(m => m.Street, map => map.MapFrom(l => l.location.Street));


            CreateMap<MeetupDto, Meetup>();


        }
    }
}
