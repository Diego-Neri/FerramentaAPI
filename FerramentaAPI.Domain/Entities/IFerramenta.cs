using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FerramentaAPI.Domain.Enums;
using FerramentaAPI.Domain.ValueObjects;

namespace FerramentaAPI.Domain.Entities {
    public interface IFerramenta {
        int Id { get; }
        EnderecoFerramenta Endereco { get; }
        Descricao Descricao { get; }
        double Diametro { get; }
        double Altura { get; }
        TipoFerramenta Tipo { get; }
        string Path();
    }
}
