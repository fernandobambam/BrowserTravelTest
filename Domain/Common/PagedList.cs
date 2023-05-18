using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Common
{
    /// <summary>
    /// Representa una lista paginada que hereda de la clase <see cref="List{T}"/>.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos contenidos en la lista.</typeparam>
    public class PagedList<T> : List<T>
    {
        #region propiedades

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        /// <summary>
        /// Obtiene un valor que indica si existe una página anterior a la actual.
        /// </summary>
        public bool HasPreviousPage => CurrentPage > 1;

        /// <summary>
        /// Obtiene un valor que indica si existe una página siguiente a la actual.
        /// </summary>
        public bool HasNextPage => CurrentPage < TotalPages;

        /// <summary>
        /// Obtiene el número de página siguiente si existe, de lo contrario, devuelve null.
        /// </summary>
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;

        /// <summary>
        /// Obtiene el número de página anterior si existe, de lo contrario, devuelve null.
        /// </summary>
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

        #endregion

        #region Constructor

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        #endregion

        #region Metodos Publicos 

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="PagedList{T}"/> a partir de una colección fuente.
        /// </summary>
        /// <param name="source">La colección fuente de elementos.</param>
        /// <param name="pageNumber">El número de página deseado.</param>
        /// <param name="pageSize">El tamaño de página deseado.</param>
        /// <returns>Una instancia de la clase <see cref="PagedList{T}"/>.</returns>
        public static PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        #endregion
    }
}
