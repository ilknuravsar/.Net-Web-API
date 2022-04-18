using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Model;

namespace WebApplication3
{
    public class PersonelProfile : Profile 
    {
        public PersonelProfile()
        {
            CreateMap<Personel, PersonelDto>();
            CreateMap<PersonelDto, Personel>();
        }
    }
}
