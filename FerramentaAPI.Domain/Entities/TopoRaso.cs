using FerramentaAPI.Domain.Enums;
using FerramentaAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaAPI.Domain.Entities {
    public class TopoRaso : Ferramenta {
        public TopoRaso(EnderecoFerramenta endereco, Descricao descricao, double diametro, double altura)
            : base(endereco, descricao, diametro, altura, TipoFerramenta.TopoRaso) {
        }

        public override string Path() => "Caminho tradicional";
    }
}
