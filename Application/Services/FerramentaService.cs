using Application.DTOs;
using Application.Interfaces;
using FerramentaAPI.Domain.Entities;
using FerramentaAPI.Domain.Enums;
using FerramentaAPI.Domain.Interfaces;
using FerramentaAPI.Domain.ValueObjects;
using FerramentaAPI.Infra.Enums;
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

        public FerramentaDTO GetFerramentaById(int id)
        {
            var ferramenta = _ferramentaRepository.GetById(id);
            return ferramenta == null ? new FerramentaDTO() : MapToDto(ferramenta);
        }

        public IEnumerable<FerramentaDTO> GetAllFerramentas() {
            return _ferramentaRepository.GetAll().Select(MapToDto);
        }

        public async Task AddFerramenta(FerramentaCreateDTO ferramentaDTO) {
            var endereco = new EnderecoFerramenta(ferramentaDTO.Endereco);
            var descricao = new Descricao(ferramentaDTO.Descricao);
            IFerramenta novaferramenta = ferramentaDTO.Tipo switch {
                TipoFerramenta.VBit => new VBit(endereco, descricao, ferramentaDTO.Diametro, ferramentaDTO.Altura),
                TipoFerramenta.TopoRaso => new TopoRaso(endereco, descricao, ferramentaDTO.Diametro, ferramentaDTO.Altura),
                _ => throw new ArgumentException("Tipo de ferramenta inválido.")
            };

            _ferramentaRepository.Add(novaferramenta);
            await _discordLogs.LogsAsync($"Ferramenta adicionada: Endereço: {novaferramenta.Endereco.Valor} - Descrição: {novaferramenta.Descricao.Valor} - Tipo: {novaferramenta.Tipo}", LogLevel.WARNING);
        }

        public async Task UpdateFerramenta(int id, FerramentaCreateDTO ferramentaDTO) {
            var ferramenta = _ferramentaRepository.GetById(id);
            if (ferramenta == null) {
                await _discordLogs.LogsAsync($"Erro ao atualizar ferramenta: Ferramenta não encontrada: {id}", LogLevel.ERROR);
                throw new ArgumentException("Ferramenta não encontrada.");
            }
            var endereco = new EnderecoFerramenta(ferramentaDTO.Endereco);
            var descricao = new Descricao(ferramentaDTO.Descricao);
            IFerramenta novaferramenta = ferramentaDTO.Tipo switch {
                TipoFerramenta.VBit => new VBit(endereco, descricao, ferramentaDTO.Diametro, ferramentaDTO.Altura),
                TipoFerramenta.TopoRaso => new TopoRaso(endereco, descricao, ferramentaDTO.Diametro, ferramentaDTO.Altura),
                
                _ => throw new ArgumentException("Tipo de ferramenta inválido.")
            };

            novaferramenta.GetType().GetProperty("Id")?.SetValue(novaferramenta, id);
            _ferramentaRepository.Update(novaferramenta);
            await _discordLogs.LogsAsync($"Ferramenta atualizada: Endereço: {novaferramenta.Endereco.Valor} - Descrição: {novaferramenta.Descricao.Valor} - Tipo: {novaferramenta.Tipo}", LogLevel.INFO);
        }

        public async Task DeleteFerramenta(int id)
        {
            var ferramenta = _ferramentaRepository.GetById(id);
            if (ferramenta == null) {
                //return Result.Error("Ferramenta não encontrada.");
                await _discordLogs.LogsAsync($"Erro ao deletar ferramenta: Ferramenta não encontrada: {id}", LogLevel.ERROR);
                throw new ArgumentException("Ferramenta não encontrada.");
                
            }
           _ferramentaRepository.Delete(ferramenta, id);
           await _discordLogs.LogsAsync($"Ferramenta deletada: {id}", LogLevel.INFO);
        }

        private FerramentaDTO MapToDto(IFerramenta ferramenta) {
            return new FerramentaDTO {
                Id = ferramenta.Id,
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
