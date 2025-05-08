using Application.DTOs;
using Application.Interfaces;
using FerramentaAPI.Application.Result;
using FerramentaAPI.Infra.Logs;
using FerramentaAPI.Infra.Enums;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FerramentaAPI.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FerramentaController : ControllerBase
    {
        private readonly IFerramentaService _service;
        private readonly DiscordLogs _discordLogs;
        public FerramentaController(IFerramentaService service, DiscordLogs discord)
        {
            _discordLogs = discord;
            _service = service;
        }
        [HttpPost]
        public ActionResult Add(FerramentaCreateDTO ferramentaDto)
        {
            _service.AddFerramenta(ferramentaDto);
            return CreatedAtAction(nameof(Get), new { id = ferramentaDto.Id }, ferramentaDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FerramentaDTO>> Get()
        {
            return Ok(_service.GetAllFerramentas());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FerramentaDTO>> Get(int id, DateTime data)
        {
            var ferramenta = _service.GetFerramentaById(id);
            if (ferramenta == null) {
                await _discordLogs.LogsAsync($"Ferramenta {id} não encontrada. DATA: {data} ", Infra.Enums.LogLevel.WARNING);
                return NotFound("Ferramenta não encontrada.");
            }
            return Ok(ferramenta);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, FerramentaCreateDTO ferramentaDto, DateTime data)
        {
            var ferramenta = _service.UpdateFerramenta(id, ferramentaDto);
            if (ferramenta == null) {
                await _discordLogs.LogsAsync($"Ferramenta {id} não encontrada. DATA: {data} ", Infra.Enums.LogLevel.WARNING);
                return NotFound("Ferramenta não encontrada");
            }
            return Ok(ferramentaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, DateTime data)
        {
          var ferramenta = _service.DeleteFerramenta(id);
            if (ferramenta == null) {
             await _discordLogs.LogsAsync($"Ferramenta {id} não encontrada. DATA: {data} ", Infra.Enums.LogLevel.WARNING);
                return NotFound("Ferramenta não encontrada");
            }
            return Ok();
        }
    }
}
