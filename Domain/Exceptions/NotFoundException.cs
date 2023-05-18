using System;

namespace Domain.Exceptions
{
    /// <summary>
    /// Representa una excepción que se lanza cuando no se encuentra un elemento específico.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }

        public NotFoundException(string message) : base(message)
        {

        }
    }
}
