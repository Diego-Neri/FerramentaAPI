
using FerramentaAPI.Domain.Entities;
using FerramentaAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaAPI.Infra.Data {
    public class InMemoryFerramentaRepository : IFerramentaRepository {
        private readonly List<IFerramenta> _ferramentas = new List<IFerramenta>();
        private int _nextId = 1;

        public void Add(IFerramenta ferramenta) {
            _ferramentas.Add(ferramenta);
            
            ferramenta.GetType().GetProperty("Id")?.SetValue(ferramenta, _nextId++);
        }

        public IFerramenta GetById(int id) {
            return _ferramentas.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<IFerramenta> GetAll() {
            return _ferramentas;
        }

        public void Update(IFerramenta ferramenta)
        {
            var index = _ferramentas.FindIndex(f => f.Id == ferramenta.Id);
            if (index == -1) {
                throw new KeyNotFoundException("Ferramenta não encontrada.");
            }
            _ferramentas[index] = ferramenta;
        }

        public void Delete(IFerramenta ferramenta, int id) {
            var ferramenta1 = GetById(id);
            if (ferramenta != null) {
                _ferramentas.Remove(ferramenta);
            }
        }
    }
}
