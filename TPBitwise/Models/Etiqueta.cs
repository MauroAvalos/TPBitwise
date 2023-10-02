namespace TPBitwise.Models
{
    public class Etiqueta
    {
        public int EtiquetaId { get; set; }
        public string Nombre { get; set; }
        public List<TareaEtiqueta> TareaEtiquetas { get; set; }
    }
}
