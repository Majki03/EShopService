using Xunit;
using EShop.Application.Services;

namespace EShop.Application.Tests;

public class CreditCardServiceCardTypeTests
{
    private readonly CreditCardService _service = new();

    [Theory]
    [InlineData("4111 1111 1111 1111", "Visa")]
    [InlineData("5500 0000 0000 0004", "MasterCard")]
    [InlineData("2222 4000 7000 0005", "MasterCard")] // MasterCard 2-series
    [InlineData("3400 0000 0000 009", "American Express")]
    [InlineData("6011 0000 0000 0004", "Discover")]
    [InlineData("3530 1113 3330 0000", "JCB")]
    [InlineData("3000 0000 0000 04", "Diners Club")]
    [InlineData("6759 0000 0000 0000", "Maestro")]
    [InlineData("9999 8888 7777 6666", "Unknown")]
    [InlineData("abcd efgh ijkl mnop", "Unknown")]
    [InlineData("", "Unknown")]
    public void GetCardType_ShouldReturnCorrectType(string cardNumber, string expectedType)
    {
        var result = _service.GetCardType(cardNumber);
        Assert.Equal(expectedType, result);
    }
}