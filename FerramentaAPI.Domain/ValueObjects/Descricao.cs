using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaAPI.Domain.ValueObjects {
    public class Descricao {
        public string Valor { get; private set; }

        public Descricao(string valor) {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length < 3)
                throw new ArgumentException("Descrição deve ter no mínimo 3 caracteres.");
            Valor = valor;
        }
    }
}
