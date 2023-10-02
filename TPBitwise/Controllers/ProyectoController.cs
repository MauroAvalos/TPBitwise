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
    public class ProyectoController : ControllerBase
    {
        private readonly IGenericRepository<Proyecto> _repository;
        private readonly IMapper _mapper;

        public ProyectoController(IGenericRepository<Proyecto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [ResponseCache (Duration = 50)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProyectoDTO>>> ObtenerTodos()
        {
            var proyectos = await _repository.ObtenerTodos();
            var proyectosDTO = _mapper.Map<IEnumerable<ProyectoDTO>>(proyectos);
            return Ok(proyectosDTO);
        }

        [ResponseCache(Duration = 50)]
        [HttpGet("{id}", Name = "GetProyecto")]
        public async Task<ActionResult<Proyecto>> Obtener(int id)
        {
            var proyecto = await _repository.Obtener(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            var proyectoDto = _mapper.Map<ProyectoDTO>(proyecto);
            return Ok(proyectoDto);
        }

        [HttpPost]

        public async Task<ActionResult> Crear(ProyectoCreacionDTO proyectoCreacionDTO)
        {
            if (proyectoCreacionDTO == null)
            {
                return BadRequest("El proyecto no puede ser nulo.");
            }

            var proyecto = _mapper.Map<Proyecto>(proyectoCreacionDTO);

            var resultado = await _repository.Insertar(proyecto);

            if (!resultado)
            {
                return BadRequest("Error al insertar el proyecto.");
            }

            var dto = _mapper.Map<ProyectoDTO>(proyecto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ProyectoCreacionDTO proyectoCreacionDTO)
        {
            var proyectoDesdeRepo = await _repository.Obtener(id);
            if (proyectoDesdeRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(proyectoCreacionDTO, proyectoDesdeRepo);

            var resultado = await _repository.Actualizar(proyectoDesdeRepo);
            if (resultado)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var proyectoDesdeRepo = await _repository.Obtener(id);
            if (proyectoDesdeRepo == null)
            {
                return NotFound();
            }

            var resultado = await _repository.Eliminar(id);
            if (resultado)
            {
                return NoContent();
            }

            return BadRequest();

        }
    }
}
