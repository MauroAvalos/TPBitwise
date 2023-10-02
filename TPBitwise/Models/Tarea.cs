namespace TPBitwise.Models
{
    public class Tarea
    {
        public int TareaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
        public List<TareaEtiqueta> TareaEtiquetas { get; set; }
    }
}
