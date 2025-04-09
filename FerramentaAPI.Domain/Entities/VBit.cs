using FerramentaAPI.Domain.Enums;
using FerramentaAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaAPI.Domain.Entities {
    public class VBit : Ferramenta {

        public VBit(EnderecoFerramenta endereco, Descricao descricao, double diametro, double altura)
            : base(endereco, descricao, diametro, altura, TipoFerramenta.VBit) {
        }

        public override string Path() => "Subir nos cantos";
    }
}

