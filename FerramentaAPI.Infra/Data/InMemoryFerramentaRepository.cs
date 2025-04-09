
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
            return _ferramentas.FirstOrDefault(f => f.GetHashCode() == id);
        }

        public IEnumerable<IFerramenta> GetAll() {
            return _ferramentas;
        }

        public void Update(IFerramenta ferramenta) {
            var existing = GetById(ferramenta.GetHashCode());
            if (existing != null) {
                _ferramentas.Remove(existing);
                _ferramentas.Add(ferramenta);
            }
        }

        public void Delete(int id) {
            var ferramenta = GetById(id);
            if (ferramenta != null) {
                _ferramentas.Remove(ferramenta);
            }
        }
    }
}
