using System;

namespace EShop.Domain.Exceptions
{
    /// <summary>
    /// Wyjątek rzucany, gdy numer karty jest zbyt krótki.
    /// </summary>
    public class CardNumberTooShortException : Exception
    {
        public CardNumberTooShortException()
            : base("Numer karty jest zbyt krótki.") { }

        public CardNumberTooShortException(string message)
            : base(message) { }

        public CardNumberTooShortException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}