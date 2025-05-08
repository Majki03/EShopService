using System;

namespace EShop.Domain.Exceptions
{
    /// <summary>
    /// Wyjątek rzucany, gdy numer karty nie przechodzi walidacji (np. suma kontrolna).
    /// </summary>
    public class CardNumberInvalidException : Exception
    {
        public CardNumberInvalidException()
            : base("Numer karty jest niepoprawny – nie przechodzi walidacji.") { }

        public CardNumberInvalidException(string message)
            : base(message) { }

        public CardNumberInvalidException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}