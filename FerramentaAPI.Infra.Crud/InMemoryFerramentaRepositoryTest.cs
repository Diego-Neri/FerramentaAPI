using FerramentaAPI.Infra.Data;
using FerramentaAPI.Domain.Entities;
using FerramentaAPI.Domain.ValueObjects;

namespace FerramentaAPI.Infra.Test {
    public class InMemoryFerramentaRepositoryTest {
        private InMemoryFerramentaRepository repository;
        private VBit ferramenta1;
        private TopoRaso ferramenta2;

        public InMemoryFerramentaRepositoryTest() {
            repository = new InMemoryFerramentaRepository();
            ferramenta1 = new VBit(new EnderecoFerramenta("Rua A,  123"), new Descricao("Furadeira"), 10, 5);
            ferramenta2 = new TopoRaso(new EnderecoFerramenta("Rua B,  456"), new Descricao("Furadeira"), 10, 5);
        }


        [Fact]
        public void Add_AdicionarFerramenta() {
            repository.Add(ferramenta1);

            var retorno = repository.GetById(ferramenta1.GetHashCode());
            Assert.NotNull(retorno);
            Assert.Equal(ferramenta1, retorno);
        }

        [Fact]
        public void GetById_PegarFerramentaPorId() {
            
            repository.Add(ferramenta2);
            var retorno = repository.GetById(ferramenta2.GetHashCode());
            Assert.NotNull(retorno);
            Assert.Equal(ferramenta2, retorno);
        }

        [Fact]
        public void GetAll_PegarTodasFerramentas() {
            repository.Add(ferramenta1);
            repository.Add(ferramenta2);
            var retorno = repository.GetAll();
            Assert.NotNull(retorno);
            Assert.Equal(2, retorno.Count());
        }

        [Fact]
        public void Update_AtualizarFerramenta() {
            repository.Add(ferramenta1);
            ferramenta1.Descricao = new Descricao("Diego Neri");
            repository.Update(ferramenta1);

            var retorno = repository.GetById(ferramenta1.GetHashCode());
            Assert.NotNull(retorno);
            Assert.Equal(ferramenta1.Descricao, retorno.Descricao);

        }

        [Fact]
        public void Delete_DeletarFerramenta() {
            repository.Add(ferramenta2);
            repository.Delete(ferramenta2.GetHashCode());
            var retorno = repository.GetById(ferramenta2.GetHashCode());
            Assert.Null(retorno);

        }
    }
}
