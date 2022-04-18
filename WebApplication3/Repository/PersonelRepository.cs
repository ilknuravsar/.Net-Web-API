using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Model;

namespace WebApplication3.Repository
{
    public class PersonelRepository : IPersonelRepository
    {
  

        
        public List<Personel> GetAllPersonel()
        {
            throw new NotImplementedException();
        }

        Personel IPersonelRepository.Add(Personel personel)
        {
            throw new NotImplementedException();
        }

        Personel IPersonelRepository.Update(Personel personel)
        {
            throw new NotImplementedException();
        }
    }

}
