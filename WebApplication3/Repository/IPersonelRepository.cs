using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Model
{
    public interface IPersonelRepository
    {
        Personel Add(Personel personel);
        List<Personel> GetAllPersonel();
        Personel Update(Personel personel);
    }
}