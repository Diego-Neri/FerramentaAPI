using FerramentaAPI.Domain.Entities;
using FerramentaAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaAPI.Domain.Test {
    public class FerramentaTest {

        /// Testa o método Path da classe VBit <summary>
        /// Testa o método Path da classe VBit e TopoRaso
        /// Arrange É aqui que você normalmente prepara tudo para o teste, em outras palavras, prepara a cena para testar (criar os objetos e configurá-los conforme necessário)
        /// Act É aqui que você executa o código que deseja testar (chama o método ou função que está testando)
        /// Assert comparamos o que esperamos que aconteça com o resultado real da execução do método de teste
        /// </summary>

        [Fact]
        public void VBit_Path_RetornarSubirNosCantos() {

            //Arrange
            var endereco = new EnderecoFerramenta("Rua A, 123");
            var descricao = new Descricao("Ferramenta de teste");

            //Act
            var vbit = new VBit(endereco, descricao, 10, 10);


            Assert.Equal("Subir nos cantos", vbit.Path());
        }

        [Fact]
        public void TopoRaso_Path_RetornarCaminhoTradicional() {

            //Arrange
            var endereco = new EnderecoFerramenta("Rua A, 123");
            var descricao = new Descricao("Ferramenta de teste");

            //Act
            var topoRaso = new TopoRaso(endereco, descricao, 10, 10);

            //Assert
            Assert.Equal("Caminho tradicional", topoRaso.Path());
        }

        [Fact]
        public void EnderecoFerramenta_LancarExececao_QuandoCaracterNull() {

            Assert.Throws<ArgumentException>(() => new EnderecoFerramenta(""));
        }

        [Fact]
        public void EnderecoFerramenta_LancarExececao_QuandoCaracterMaior50() {
            Assert.Throws<ArgumentException>(() => new EnderecoFerramenta("Olá, me chamo Diego. Tenho 21 anos! Estudante de Análise e Desenvolvimento de Sistemas!"));
        }

        [Fact]
        public void EnderecoFerramenta_LancarExececao_QuandoCaracterMenor3Caracteres() {
            Assert.Throws<ArgumentException>(() => new Descricao("ab"));
        }

        [Fact]
        public void Ferramenta_LancarExececao_QuandoDiametroMenorQueZeroOuMaiorQueCem() {
            var Endereco = new EnderecoFerramenta("Rua 1");
            var Descricao = new Descricao("Furadeira");
            Assert.Throws<ArgumentException>(() => new VBit(Endereco, Descricao, 0, 101));
        }

        [Fact]
        public void Ferramenta_LancarExececao_QuandoAlturaMenorQueZeroOuMaiorQueCem() {
            var Endereco = new EnderecoFerramenta("Rua 1");
            var Descricao = new Descricao("Furadeira");
            Assert.Throws<ArgumentException>(() => new VBit(Endereco, Descricao, 0, 101));
        }
    }
}
