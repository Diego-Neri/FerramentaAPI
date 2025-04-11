using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FerramentaAPI.Presentation.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class FerramentaController : ControllerBase {
        private readonly IFerramentaService _service;
        public FerramentaController(IFerramentaService service) {
            _service = service;
        }
        [HttpPost]
        public ActionResult Add(FerramentaCreateDTO ferramentaDto) {
            _service.AddFerramenta(ferramentaDto);
            return CreatedAtAction(nameof(Get), new { id = ferramentaDto.GetHashCode() }, ferramentaDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FerramentaDTO>> Get() {
            return Ok(_service.GetAllFerramentas());
        }


        [HttpGet("{id}")]
        public ActionResult<FerramentaDTO> Get(int id) {
            var ferramenta = _service.GetFerramentaById(id);
            //Retorna notfound se a ferramenta não existir, caso contrário, retorna a ferramenta
            return ferramenta == null ? NotFound("Ferramenta não encontrada.") : Ok(ferramenta);
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, FerramentaCreateDTO ferramentaDto) {
            _service.UpdateFerramenta(id, ferramentaDto);
            return _service == null ? NotFound("Ferramenta não encontrada") : Ok(ferramentaDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            _service.DeleteFerramenta(id);
            return _service == null ? NotFound("Ferramenta não encontrada") : Ok();
        }
    }
}
