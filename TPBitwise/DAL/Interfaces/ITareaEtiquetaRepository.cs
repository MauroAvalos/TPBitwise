using TPBitwise.Models;

namespace TPBitwise.DAL.Interfaces
{
    public interface ITareaEtiquetaRepository : IGenericRepository<TareaEtiqueta>
    {
        Task<TareaEtiqueta> ObtenerPorIdCompuesto(int tareaId, int etiquetaId);
        Task<bool> EliminarPorIdCompuesto(int tareaId, int etiquetaId);
    }
}
