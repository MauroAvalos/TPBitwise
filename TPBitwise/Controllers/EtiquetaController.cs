using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPBitwise.DAL.Interfaces;
using TPBitwise.DTO;
using TPBitwise.Models;

namespace TPBitwise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtiquetaController : ControllerBase
    {
        private readonly IGenericRepository<Etiqueta> _repository;
        private readonly IMapper _mapper;

        public EtiquetaController(IGenericRepository<Etiqueta> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtiquetaDTO>>> ObtenerTodos()
        {
            var etiquetas = await _repository.ObtenerTodos();
            var etiquetasDTO = _mapper.Map<IEnumerable<EtiquetaDTO>>(etiquetas);
            return Ok(etiquetasDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EtiquetaDTO>> Obtener(int id)
        {
            var etiqueta = await _repository.Obtener(id);
            if (etiqueta == null)
            {
                return NotFound();
            }
            var etiquetaDTO = _mapper.Map<EtiquetaDTO>(etiqueta);
            return Ok(etiquetaDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, EtiquetaDTO etiquetaDTO)
        {
            var etiqueta = _mapper.Map<Etiqueta>(etiquetaDTO);
            if (id != etiqueta.EtiquetaId)
            {
                return BadRequest();
            }

            var resultado = await _repository.Actualizar(etiqueta);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<EtiquetaDTO>> Insertar(EtiquetaDTO etiquetaDTO)
        {
            var etiqueta = _mapper.Map<Etiqueta>(etiquetaDTO);
            var resultado = await _repository.Insertar(etiqueta);
            if (resultado)
            {
                var nuevoEtiquetaDTO = _mapper.Map<EtiquetaDTO>(etiqueta);
                return CreatedAtAction("GetEtiqueta", new { id = nuevoEtiquetaDTO.EtiquetaId }, nuevoEtiquetaDTO);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _repository.Eliminar(id);
            if (resultado)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}
