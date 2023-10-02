using TPBitwise.DTO;
using TPBitwise.Models;

namespace TPBitwise.DAL.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<bool> IsUniqueUsuario(string usuario);
        Task<UsuarioDatosDTO> Registro(UsuarioRegistroDTO usuarioRegistroDTO);
        Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLoginDTO);
    }
}
