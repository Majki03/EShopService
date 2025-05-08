using System;

namespace EShop.Domain.Exceptions
{
    /// <summary>
    /// Wyjątek rzucany, gdy numer karty jest zbyt długi.
    /// </summary>
    public class CardNumberTooLongException : Exception
    {
        public CardNumberTooLongException()
            : base("Numer karty jest zbyt długi.") { }

        public CardNumberTooLongException(string message)
            : base(message) { }

        public CardNumberTooLongException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}