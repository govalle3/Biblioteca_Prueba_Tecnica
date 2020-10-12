using BibliotecaRepositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaRepositorioContexto
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions<BibliotecaContexto> options):base(options)
        {
            Database.EnsureCreated();  
        }
        
        public Microsoft.EntityFrameworkCore.DbSet<LibroEntidad> Libros { get; set; }  // Se establecen las directivas en ese lugar ya que presenta ambiguedad entre el metodo sistem.data.entity
        public Microsoft.EntityFrameworkCore.DbSet<PrestamoEntidad> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("BibliotecaBD");
            } 
        }
    }
}
