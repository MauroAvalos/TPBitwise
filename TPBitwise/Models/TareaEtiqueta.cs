namespace TPBitwise.Models
{
    public class TareaEtiqueta
    {
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }
        public int EtiquetaId { get; set; }
        public Etiqueta Etiqueta { get; set; }
    }
}
