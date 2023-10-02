using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TPBitwise.Models;

namespace TPBitwise.DAL.DataContext
{
    public class AppDbContext : IdentityDbContext<AppUsuario>
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TareaEtiqueta>()
                .HasKey(te => new { te.TareaId, te.EtiquetaId }); 
            modelBuilder.Entity<TareaEtiqueta>()
                .HasOne(te => te.Tarea)
                .WithMany(t => t.TareaEtiquetas)
                .HasForeignKey(te => te.TareaId);
            modelBuilder.Entity<TareaEtiqueta>()
                .HasOne(te => te.Etiqueta)
                .WithMany(e => e.TareaEtiquetas)
                .HasForeignKey(te => te.EtiquetaId);
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<TareaEtiqueta> TareaEtiquetas { get; set; }
        public DbSet<AppUsuario> AppUsuarios { get; set;}
    }
}
