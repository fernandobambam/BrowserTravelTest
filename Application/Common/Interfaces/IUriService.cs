using System;

namespace Application.Common.Interfaces
{
    public interface IUriService
    {
        /// <summary>
        /// Obtiene una URI que incluye los parámetros de paginación y la URL de acción proporcionada.
        /// </summary>
        /// <param name="PageSize">El tamaño de página.</param>
        /// <param name="PageNumber">El número de página.</param>
        /// <param name="actionUrl">La URL de acción.</param>
        /// <returns>Una instancia de la clase Uri.</returns>
        Uri GetAllEntities(int PageSize, int PageNumber, string actionUrl);
    }
}
