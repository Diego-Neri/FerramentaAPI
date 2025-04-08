using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaAPI.Domain.ValueObjects {
    public class EnderecoFerramenta {
        public string Valor { get; private set; }

        public EnderecoFerramenta(string valor) {

            if (string.IsNullOrWhiteSpace(valor) || valor.Length < 1 || valor.Length > 50)
                throw new ArgumentException("Endereço deve ter entre 1 e 50 caracteres.");
            Valor = valor;
        }
    }
}
