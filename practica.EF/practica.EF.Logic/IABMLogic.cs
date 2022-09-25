using practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();

        void Add(T newAdd);

        void Delete(string id);

        void Update(T newUpd);
    }
}
