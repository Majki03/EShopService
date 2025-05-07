using Xunit;
using EShop.Application.Services;

namespace EShop.Application.Tests;

public class CreditCardServiceTests
{
    private readonly CreditCardService _service = new();

    [Theory]
    [InlineData("4111 1111 1111 1111", true, "Visa")]
    [InlineData("5500 0000 0000 0004", true, "MasterCard")]
    [InlineData("3400 0000 0000 009", true, "American Express")]
    [InlineData("0000 0000 0000 0000", false, "Unknown")] // typ rozpoznany, ale numer nieważny
    [InlineData("abcd efgh ijkl mnop", false, "Unknown")]
    [InlineData("4111-1111-1111-1110", false, "Visa")] // typ rozpoznany, Luhn nie przechodzi
    public void Analyze_ReturnsExpectedResult(string number, bool isValid, string type)
    {
        var result = _service.Analyze(number);

        Assert.Equal(isValid, result.IsValid);
        Assert.Equal(type, result.CardType);
    }
}