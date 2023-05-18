using System;

namespace Domain.Exceptions
{
    /// <summary>
    /// Representa una excepción relacionada con un error en la lógica de negocio.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string message) : base(message)
        {

        }
    }
}
