using FerramentaAPI.Domain.Entities;
using FerramentaAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaAPI.Domain.Test {
    public class FerramentaTest {

        [Fact]
        public void VBit_Path_RetornarSubirNosCantos() {

            //Arrange
            var endereco = new EnderecoFerramenta("Rua A, 123");
            var descricao = new Descricao("Ferramenta de teste");
            var vbit = new VBit(endereco, descricao, 10, 10);
            Assert.Equal("Subir nos cantos", vbit.Path());
        }

    }
}
