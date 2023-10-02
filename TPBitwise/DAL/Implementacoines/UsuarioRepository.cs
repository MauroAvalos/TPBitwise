using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TPBitwise.DAL.DataContext;
using TPBitwise.DAL.Interfaces;
using TPBitwise.DTO;
using TPBitwise.Models;
using XSystem.Security.Cryptography;

namespace TPBitwise.DAL.Implementacoines
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;
        private string claveSecreta;
        private readonly UserManager<AppUsuario> _userManager;
        private readonly IMapper _mapper;
        public UsuarioRepository(AppDbContext context, IConfiguration config, UserManager<AppUsuario> userManager, IMapper mapper) : base(context)
        {
            _context = context;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta"); 
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> IsUniqueUsuario(string usuario)
        {
            var usuarioDb = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == usuario);
            if (usuarioDb == null)
            {
                return true;
            }
            return false;
        }

        public async Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            
            var usuarioEncontrado = await _context.AppUsuarios.FirstOrDefaultAsync(
                                             u => u.UserName.ToLower() == usuarioLoginDTO.NombreUsuario.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(usuarioEncontrado, usuarioLoginDTO.Password);

            if (usuarioEncontrado == null || isValid == false)
            {
                return new UsuarioLoginRespuestaDTO()
                {
                    Token = "",
                    Usuario = null
                };

            }

            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioEncontrado.UserName.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = manejadorToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDTO usuarioLoginRespuestaDTO = new UsuarioLoginRespuestaDTO()
            {
                Token = manejadorToken.WriteToken(token),
                Usuario = _mapper.Map<UsuarioDatosDTO>(usuarioEncontrado)
            };

            return usuarioLoginRespuestaDTO;    
        }

        public async Task<UsuarioDatosDTO> Registro(UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var usuarioNuevo = new AppUsuario()
            {
                UserName = usuarioRegistroDTO.NombreUsuario,
                
                Nombre = usuarioRegistroDTO.Nombre,
                Email = usuarioRegistroDTO.Email
            };

            var result = await _userManager.CreateAsync(usuarioNuevo, usuarioRegistroDTO.Password);
            if (result.Succeeded)
            {
                var usuarioRetornado = await _context.AppUsuarios.FirstOrDefaultAsync(u => u.UserName == usuarioRegistroDTO.NombreUsuario);

                return _mapper.Map<UsuarioDatosDTO>(usuarioRetornado);
            }
            return null;
            
        }
    }
}
