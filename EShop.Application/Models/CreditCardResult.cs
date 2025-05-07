namespace EShop.Application.Models;

public class CreditCardResult
{
    public bool IsValid { get; set; }
    public string CardType { get; set; } = "Unknown";
}