using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPBitwise.DAL.DataContext;
using TPBitwise.DAL.Interfaces;
using TPBitwise.DTO;
using TPBitwise.Models;

namespace TPBitwise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly IGenericRepository<Tarea> _repository;
        private readonly IMapper _mapper;

        public TareaController(IGenericRepository<Tarea> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;          
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaDTO>>> ObtenerTodos()
        {
            var tareas = await _repository.ObtenerTodos();
            var tareasDTO = _mapper.Map<IEnumerable<ProyectoDTO>>(tareas);
            return Ok(tareasDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TareaDTO>> Obtener(int id)
        {
            var tarea = await _repository.Obtener(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TareaDTO>(tarea));
        }

        
        [HttpPost]
        public async Task<ActionResult<TareaDTO>> Crear(TareaCreacionDTO tareaCreacionDTO)
        {
            var tarea = _mapper.Map<Tarea>(tareaCreacionDTO);
            await _repository.Insertar(tarea);

            var tareaDTO = _mapper.Map<TareaDTO>(tarea);

            return CreatedAtAction(nameof(Obtener), new { id = tarea.TareaId }, tareaDTO);
        }
    }
}
