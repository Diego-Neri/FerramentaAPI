using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface IFerramentaService {

        FerramentaDTO GetFerramentaById(int id);
        IEnumerable<FerramentaDTO> GetAllFerramentas();
        void AddFerramenta(FerramentaCreateDTO ferramentaDTO);
        void UpdateFerramenta(int id, FerramentaCreateDTO ferramentaDTO);
        void DeleteFerramenta(int id);
    }
}
