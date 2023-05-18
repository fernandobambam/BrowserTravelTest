using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// Representa un contexto de prueba de navegación en un navegador.
    /// </summary>
    public interface IBrowserTravelTestContext
    {
        /// <summary>
        /// Obtiene o establece el DbSet de Autors.
        /// </summary>
        DbSet<Autor> Autors { get; set; }

        /// <summary>
        /// Obtiene o establece el DbSet de Autors.
        /// </summary>
        DbSet<Editorial> Editorials { get; set; }

        /// <summary>
        /// Obtiene o establece el DbSet de Libros.
        /// </summary>
        DbSet<Libro> Libros { get; set; }

        /// <summary>
        /// Obtiene o establece el DbSet de AutorLibros
        /// </summary>
        public DbSet<AutorLibro> AutorLibros { get; set; }

        /// <summary>
        /// Guarda los cambios de forma asíncrona en la base de datos subyacente.
        /// </summary>
        /// <param name="cancellationToken">El token de cancelación.</param>
        /// <returns>Una tarea que representa la operación de guardado asíncrona.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
