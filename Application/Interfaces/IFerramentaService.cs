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
        Task AddFerramenta(FerramentaCreateDTO ferramentaDTO);
        Task UpdateFerramenta(int id, FerramentaCreateDTO ferramentaDTO);
        Task DeleteFerramenta(int id);
    }
}
