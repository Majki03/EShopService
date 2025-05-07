using System.Linq;
using System.Text.RegularExpressions;
using EShop.Application.Models;

namespace EShop.Application.Services;

public class CreditCardService
{
    public CreditCardResult Analyze(string cardNumber)
    {
        var cleaned = cardNumber.Replace(" ", "").Replace("-", "");

        var result = new CreditCardResult
        {
            IsValid = ValidateLuhn(cleaned),
            CardType = GetCardType(cleaned)
        };

        // Jeśli nie zawiera tylko cyfr lub ma złą długość, to i tak niepoprawna
        if (!cleaned.All(char.IsDigit) || cleaned.Length < 13 || cleaned.Length > 19)
            result.IsValid = false;

        // np. dla "0000 0000 0000 0000"
        if (cleaned.Distinct().Count() == 1)
            result.IsValid = false;

        return result;
    }

    private bool ValidateLuhn(string number)
    {
        int sum = 0;
        bool alternate = false;

        for (int i = number.Length - 1; i >= 0; i--)
        {
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

    public string GetCardType(string cardNumber)
    {
        // Usunięcie spacji i myślników
        var number = cardNumber.Replace(" ", "").Replace("-", "");

        // VISA: zaczyna się od 4 i ma 13, 16 lub 19 cyfr
        if (Regex.IsMatch(number, @"^4\d{12}(\d{3})?(\d{3})?$"))
            return "Visa";

        // MasterCard: klasyczny zakres 51–55 oraz nowy zakres 2221–2720
        if (Regex.IsMatch(number, @"^(5[1-5]\d{14}|2(2[2-9]\d|[3-6]\d{2}|7([01]\d|20))\d{12})$"))
            return "MasterCard";

        // American Express: 34 lub 37, 15 cyfr
        if (Regex.IsMatch(number, @"^3[47]\d{13}$"))
            return "American Express";

        // Discover: 6011, 65xx, lub 64[4–9], 16 cyfr
        if (Regex.IsMatch(number, @"^6(011\d{12}|5\d{14}|4[4-9]\d{13})$"))
            return "Discover";

        // JCB: zakres 3528–3589, 16 cyfr
        if (Regex.IsMatch(number, @"^35(2[89]|[3-8][0-9])\d{12}$"))
            return "JCB";

        // Diners Club: 300–305, 36, 38, 14 cyfr
        if (Regex.IsMatch(number, @"^3(0[0-5]|[68]\d)\d{11}$"))
            return "Diners Club";

        // Maestro: różne prefiksy, 12–19 cyfr
        if (Regex.IsMatch(number, @"^(50|5[6-9]|6\d)\d{10,17}$"))
            return "Maestro";

        return "Unknown";
    }

}