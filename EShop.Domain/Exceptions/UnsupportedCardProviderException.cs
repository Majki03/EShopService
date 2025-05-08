using System;

namespace EShop.Domain.Exceptions
{
    public class UnsupportedCardProviderException : Exception
    {
        public UnsupportedCardProviderException()
            : base("Dostawca karty nie jest wspierany (Visa, MasterCard, American Express).") { }

        public UnsupportedCardProviderException(string message)
            : base(message) { }

        public UnsupportedCardProviderException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}