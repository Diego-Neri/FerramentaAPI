using FerramentaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaAPI.Domain.Interfaces {
    public interface IFerramentaRepository {
        void Add(IFerramenta ferramenta);
        IFerramenta GetById(int id);
        IEnumerable<IFerramenta> GetAll();
        void Update(IFerramenta ferramenta);
        void Delete(int id);
    }
}
