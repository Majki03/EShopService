using EShop.Domain.Enums;
using EShop.Domain.Exceptions;

namespace EShop.Domain.Services
{
    public static class CreditCardValidator
    {
        public static CreditCardProvider Validate(string cardNumber)
        {
            if (cardNumber.Length > 19)
                throw new CardNumberTooLongException();

            if (cardNumber.Length < 13)
                throw new CardNumberTooShortException();

            if (!IsValidLuhn(cardNumber))
                throw new CardNumberInvalidException();

            var provider = DetectProvider(cardNumber);
            if (provider == null)
                throw new UnsupportedCardProviderException();

            return provider.Value;
        }

        private static bool IsValidLuhn(string number)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(number[i])) return false;

                int digit = number[i] - '0';
                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }
                sum += digit;
                alternate = !alternate;
            }

            return (sum % 10 == 0);
        }

        private static CreditCardProvider? DetectProvider(string number)
        {
            if (number.StartsWith("4"))
                return CreditCardProvider.Visa;

            if (number.StartsWith("5") && number.Length >= 2 &&
                int.TryParse(number.Substring(0, 2), out int mcPrefix) &&
                mcPrefix >= 51 && mcPrefix <= 55)
                return CreditCardProvider.MasterCard;

            if ((number.StartsWith("34") || number.StartsWith("37")) && number.Length == 15)
                return CreditCardProvider.AmericanExpress;

            return null;
        }
    }
}