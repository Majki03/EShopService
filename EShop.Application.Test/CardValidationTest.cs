using Newtonsoft.Json.Linq;

namespace EShop.Application.Test;

public class CardValidationTests
{
    [Theory]
    [InlineData("3497 7965 8312 797", true)]
    [InlineData("2221032022465829", true)]
    [InlineData("378523393817437", true)]
    [InlineData("4024 0071 6540 1778", true)]
    [InlineData("111 111 111", false)]
    public void ValidateCard_CheckLength_ReturnsCorrectValue(string cardNumber, bool expected)
    {
        // Arange 
        var cardValidator = new CardValidator();

        // Act
        var result = cardValidator.ValidateCard(cardNumber);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("3497 7965 8312 797", "American Express")]
    [InlineData("5221032022465829", "MasterCard")]
    [InlineData("378523393817437", "American Express")]
    [InlineData("4024 0071 6540 1778", "Visa")]
    [InlineData("111 111 111", "That's not a valid card number")]
    public void GetCardType_ChecksValusesType_ReturnsCorrectType(string cardNumber, string expectedResult)
    {
        // Arange 
        var cardValidator = new CardValidator();

        // Act
        var result = cardValidator.GetCardType(cardNumber);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}