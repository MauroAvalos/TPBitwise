using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPBitwise.DAL.Interfaces;
using TPBitwise.DTO;
using TPBitwise.Models;

namespace TPBitwise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaEtiquetaController : ControllerBase
    {
        private readonly ITareaEtiquetaRepository _tareaEtiquetaRepository;
        private readonly IMapper _mapper;

        public TareaEtiquetaController(ITareaEtiquetaRepository tareaEtiquetaRepository, IMapper mapper)
        {
            _tareaEtiquetaRepository = tareaEtiquetaRepository;
            _mapper = mapper;
        }

        [HttpGet("{tareaId}/{etiquetaId}")]
        public async Task<ActionResult<TareaEtiquetaDTO>> ObtenerPorIdCompuesto(int tareaId, int etiquetaId)
        {
            var tareaEtiqueta = await _tareaEtiquetaRepository.ObtenerPorIdCompuesto(tareaId, etiquetaId);
            if (tareaEtiqueta == null)
            {
                return NotFound();
            }
            var tareaEtiquetaDTO = _mapper.Map<TareaEtiquetaDTO>(tareaEtiqueta);
            return Ok(tareaEtiquetaDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TareaEtiquetaDTO>> Crear(TareaEtiquetaCreacionDTO tareaEtiquetaCreacionDTO)
        {
            var tareaEtiqueta = _mapper.Map<TareaEtiqueta>(tareaEtiquetaCreacionDTO);
            await _tareaEtiquetaRepository.Insertar(tareaEtiqueta);
            var tareaEtiquetaDTO = _mapper.Map<TareaEtiquetaDTO>(tareaEtiqueta);
            return CreatedAtAction(nameof(ObtenerPorIdCompuesto), new { tareaId = tareaEtiqueta.TareaId, etiquetaId = tareaEtiqueta.EtiquetaId }, tareaEtiquetaDTO);
        }

        [HttpDelete("{tareaId}/{etiquetaId}")]
        public async Task<ActionResult> Eliminar(int tareaId, int etiquetaId)
        {
            var resultado = await _tareaEtiquetaRepository.EliminarPorIdCompuesto(tareaId, etiquetaId);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
