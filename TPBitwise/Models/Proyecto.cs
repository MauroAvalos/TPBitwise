using System.Threading;

namespace TPBitwise.Models
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Tarea> Tareas { get; set; }
    }
}
