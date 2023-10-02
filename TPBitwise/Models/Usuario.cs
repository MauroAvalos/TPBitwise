using System.Threading;

namespace TPBitwise.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Proyecto> Proyectos { get; set; }
    }
}
