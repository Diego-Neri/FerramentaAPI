using Moq;
using System;
using System.Collections.Generic;

using FerramentaAPI.Domain.Interfaces;
using Application.Services;
using Application.DTOs;
using System.Numerics;
using FerramentaAPI.Infra.Test;

namespace FerramentaAPI.Application.Test {
    public class FerramentaServicesTest {
        [Fact]
        public void Add_ChamarAddNoRepositorio() {

            var mock = new Mock<IFerramentaRepository>();
            var service = new FerramentaService(mock.Object);
            var dto = new FerramentaCreateDTO {
                Endereco = "Rua Diego",
                Descricao = "Diego Rua",
                Diametro = 10,
                Altura = 10,
                Tipo = Domain.Enums.TipoFerramenta.VBit,
            };

            service.AddFerramenta(dto);
            mock.Verify(m => m.Add(It.IsAny<Domain.Entities.IFerramenta>()), Times.Once());
        }

        [Fact]

        public void GetById_RetornarNull_QuandoFerramentaNaoExistir() {
            var mock = new Mock<IFerramentaRepository>();
            mock.Setup(m => m.GetById(1)).Returns((Domain.Entities.IFerramenta)null);
            var service = new FerramentaService(mock.Object);

            var result = service.GetFerramentaById(1);
            Assert.Null(result);

        }

        [Fact]
        public void GetAll_RetornarTodasFerramentas() {
            var mock = new Mock<IFerramentaRepository>();
            var ferramentas = new List<Domain.Entities.IFerramenta> {
                new Domain.Entities.VBit(new Domain.ValueObjects.EnderecoFerramenta("Rua 1"), new Domain.ValueObjects.Descricao("Descricao 1"), 10, 20),
                new Domain.Entities.TopoRaso(new Domain.ValueObjects.EnderecoFerramenta("Rua 2"), new Domain.ValueObjects.Descricao("Descricao 2"), 15, 25)
            };
            mock.Setup(m => m.GetAll()).Returns(ferramentas);
            var service = new FerramentaService(mock.Object);

            var result = service.GetAllFerramentas();
            Assert.NotNull(result);

        }
    }
}
