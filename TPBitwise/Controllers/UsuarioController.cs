using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TPBitwise.DAL.DataContext;
using TPBitwise.DAL.Interfaces;
using TPBitwise.DTO;
using TPBitwise.Models;

namespace TPBitwise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase 
    {
        private readonly IGenericRepository<AppUsuario> _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        protected RespuestaAPI _respuesta;
        
        

        public UsuarioController(IGenericRepository<AppUsuario> repository, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            this._respuesta = new RespuestaAPI();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObtenerTodos()
        {
            var usuarios = await _repository.ObtenerTodos();
            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuariosDto);
        }

        [HttpPost ("registro")]
        public async Task<IActionResult> Registro ([FromBody] UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var validacionNombre = await _usuarioRepository.IsUniqueUsuario(usuarioRegistroDTO.NombreUsuario);

            if (!validacionNombre)
            {
                _respuesta.StatusCode = HttpStatusCode.BadRequest;
                _respuesta.IsSuccess = false;
                _respuesta.ErrorMensagges.Add("El nombre del usuario ya existe");
                return BadRequest(_respuesta);
            }

            var usuario = await _usuarioRepository.Registro(usuarioRegistroDTO);
            if (usuario == null)
            {
                _respuesta.StatusCode = HttpStatusCode.BadRequest;
                _respuesta.IsSuccess = false;
                _respuesta.ErrorMensagges.Add("Error en el registro");
                return BadRequest(_respuesta);
            }
            _respuesta.StatusCode = HttpStatusCode.OK;
            _respuesta.IsSuccess = true;
            return Ok(_respuesta);

        }

        [HttpPost ("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {
            var respuestaLogin = await _usuarioRepository.Login(usuarioLoginDTO);
            if (respuestaLogin.Usuario == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuesta.StatusCode=HttpStatusCode.BadRequest;
                _respuesta.IsSuccess = false;
                _respuesta.ErrorMensagges.Add("El nombre de usuario o el password son incorrectos");
                return BadRequest(_respuesta);
            }

            _respuesta.StatusCode=HttpStatusCode.OK;
            _respuesta.IsSuccess = true;
            _respuesta.Result = respuestaLogin;
            return Ok(_respuesta);
        }
    }
}
