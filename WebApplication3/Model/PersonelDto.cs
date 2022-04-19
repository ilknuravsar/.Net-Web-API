using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Model
{
    public class PersonelDto 
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public Int64 Salary { get; set; }
        public Int64 Age { get; set; }
      
    }

}
