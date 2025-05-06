using Application.DTOs;
using Application.Interfaces;
using FerramentaAPI.Domain.Entities;
using FerramentaAPI.Domain.Enums;
using FerramentaAPI.Domain.Interfaces;
using FerramentaAPI.Domain.ValueObjects;
using FerramentaAPI.Infra.Logs;
using System;
using System.Linq;


namespace Application.Services {
    public class FerramentaService : IFerramentaService {
        private readonly IFerramentaRepository _ferramentaRepository;
        private readonly DiscordLogs _discordLogs;

        public FerramentaService(IFerramentaRepository ferramentaRepository, DiscordLogs discordLogs) {
            _ferramentaRepository = ferramentaRepository;
            _discordLogs = discordLogs;
        }

        public FerramentaDTO GetFerramentaById(int id) {
            var ferramenta = _ferramentaRepository.GetById(id);
            return ferramenta == null ? null : MapToDto(ferramenta);
        }

        public IEnumerable<FerramentaDTO> GetAllFerramentas() {
            return _ferramentaRepository.GetAll().Select(MapToDto);
        }

        public void AddFerramenta(FerramentaCreateDTO ferramentaDTO) {
            var endereco = new EnderecoFerramenta(ferramentaDTO.Endereco);
            var descricao = new Descricao(ferramentaDTO.Descricao);
            IFerramenta novaferramenta = ferramentaDTO.Tipo switch {
                FerramentaAPI.Domain.Enums.TipoFerramenta.VBit => new VBit(endereco, descricao, ferramentaDTO.Diametro, ferramentaDTO.Altura),
                FerramentaAPI.Domain.Enums.TipoFerramenta.TopoRaso => new TopoRaso(endereco, descricao, ferramentaDTO.Diametro, ferramentaDTO.Altura),
                _ => throw new ArgumentException("Tipo de ferramenta inválido.")
            };

            _ferramentaRepository.Add(novaferramenta);
            _discordLogs.LogsAsync($"Ferramenta adicionada: Endereço: {novaferramenta.Endereco.Valor} - Descrição: {novaferramenta.Descricao.Valor} - Tipo: {novaferramenta.Tipo}", "INFO");
        }

        public void UpdateFerramenta(int id, FerramentaCreateDTO ferramentaDTO) {
            var ferramenta = _ferramentaRepository.GetById(id);
            if (ferramenta == null) {
                throw new ArgumentException("Ferramenta não encontrada.");
            }
            var endereco = new EnderecoFerramenta(ferramentaDTO.Endereco);
            var descricao = new Descricao(ferramentaDTO.Descricao);
            IFerramenta novaferramenta = ferramentaDTO.Tipo switch {
                FerramentaAPI.Domain.Enums.TipoFerramenta.VBit => new VBit(endereco, descricao, ferramentaDTO.Diametro, ferramentaDTO.Altura),
                FerramentaAPI.Domain.Enums.TipoFerramenta.TopoRaso => new TopoRaso(endereco, descricao, ferramentaDTO.Diametro, ferramentaDTO.Altura),
                _ => throw new ArgumentException("Tipo de ferramenta inválido.")
            };
            _ferramentaRepository.Update(ferramenta, id);
            _discordLogs.LogsAsync($"Ferramenta atualizada: Endereço: {novaferramenta.Endereco.Valor} - Descrição: {novaferramenta.Descricao.Valor} - Tipo: {novaferramenta.Tipo}", "INFO");
        }

        public void DeleteFerramenta(int id)
        {
            var ferramenta = _ferramentaRepository.GetById(id);
            if (ferramenta is null) {
                return Result.Error("Ferramenta não encontrada.");
                //throw new ArgumentException("Ferramenta não encontrada.");
            }
            _ferramentaRepository.Delete(ferramenta, id);
            _discordLogs.LogsAsync($"Ferramenta deletada: {id}", "INFO");
        }

        private FerramentaDTO MapToDto(IFerramenta ferramenta) {
            return new FerramentaDTO {
                Id = ferramenta.GetHashCode(),
                Endereco = ferramenta.Endereco.Valor,
                Descricao = ferramenta.Descricao.Valor,
                Diametro = ferramenta.Diametro,
                Altura = ferramenta.Altura,
                Tipo = ferramenta.Tipo,
                Path = ferramenta.Path()
            };
        }

    }
}
