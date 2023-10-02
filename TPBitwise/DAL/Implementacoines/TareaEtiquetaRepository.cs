using Microsoft.EntityFrameworkCore;
using TPBitwise.DAL.DataContext;
using TPBitwise.DAL.Interfaces;
using TPBitwise.Models;

namespace TPBitwise.DAL.Implementacoines
{
    public class TareaEtiquetaRepository : GenericRepository<TareaEtiqueta>, ITareaEtiquetaRepository
    {
        private readonly AppDbContext _context;

        public TareaEtiquetaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TareaEtiqueta> ObtenerPorIdCompuesto(int tareaId, int etiquetaId)
        {
            return await _context.TareaEtiquetas
                .FirstOrDefaultAsync(te => te.TareaId == tareaId && te.EtiquetaId == etiquetaId);
        }

        public async Task<bool> EliminarPorIdCompuesto(int tareaId, int etiquetaId)
        {
            var entidad = await ObtenerPorIdCompuesto(tareaId, etiquetaId);
            if (entidad == null)
            {
                return false;
            }
            _context.TareaEtiquetas.Remove(entidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
