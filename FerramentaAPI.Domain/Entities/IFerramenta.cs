using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FerramentaAPI.Domain.Enums;
using FerramentaAPI.Domain.ValueObjects;

namespace FerramentaAPI.Domain.Entities {
    public interface IFerramenta {
        EnderecoFerramenta Endereco { get; set; }
        Descricao Descricao { get; set; }
        double Diametro { get; set; }
        double Altura { get; set; }
        TipoFerramenta Tipo { get; set; }
        string Path();
    }
}
