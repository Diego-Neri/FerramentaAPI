using FerramentaAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs {
    public class FerramentaDTO {

        public int Id { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public double Diametro { get; set; }
        public double Altura { get; set; }
        public TipoFerramenta Tipo { get; set; }
        public string Path { get; set; }
    }
}
