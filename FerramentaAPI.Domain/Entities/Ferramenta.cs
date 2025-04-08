using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FerramentaAPI.Domain.ValueObjects;
using FerramentaAPI.Domain.Enums;

namespace FerramentaAPI.Domain.Entities {
    public abstract class Ferramenta : IFerramenta {

        public EnderecoFerramenta Endereco { get;  set; }
        public Descricao Descricao { get;  set; }
        public double Diametro { get; set; }
        public double Altura { get; set; }
        public TipoFerramenta Tipo { get; set; }

        protected Ferramenta(EnderecoFerramenta endereco, Descricao descricao, double diametro, double altura, TipoFerramenta tipo) {
            if (diametro <= 0 || diametro >= 100) {
                throw new ArgumentException("Diâmetro deve ser maior que zero e menor que 100.");
            }

            if (altura <= 0 || altura >= 100)
                throw new ArgumentException("Altura deve ser maior que zero e menor que 100.");

            Endereco = endereco;
            Descricao = descricao;
            Diametro = diametro;
            Altura = altura;
            Tipo = tipo;
        }

        public abstract string Path();

    }
}
