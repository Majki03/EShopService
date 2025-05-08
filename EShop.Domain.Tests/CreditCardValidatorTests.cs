using Xunit;
using EShop.Domain.Exceptions;
using EShop.Domain.Services;

namespace EShop.Domain.Tests
{
    public class CreditCardValidatorTests
    {
        [Fact]
        public void Validate_ShouldThrowCardNumberTooLongException_WhenNumberTooLong()
        {
            // Arrange
            var cardNumber = "12345678901234567890123"; // > 19 cyfr

            // Act & Assert
            Assert.Throws<CardNumberTooLongException>(() =>
                CreditCardValidator.Validate(cardNumber));
        }

        [Fact]
        public void Validate_ShouldThrowCardNumberTooShortException_WhenNumberTooShort()
        {
            // Arrange
            var cardNumber = "123456"; // < 13 cyfr

            // Act & Assert
            Assert.Throws<CardNumberTooShortException>(() =>
                CreditCardValidator.Validate(cardNumber));
        }

        [Fact]
        public void Validate_ShouldThrowCardNumberInvalidException_WhenChecksumFails()
        {
            // Arrange
            var cardNumber = "4111111111111121"; // zła suma Luhna

            // Act & Assert
            Assert.Throws<CardNumberInvalidException>(() =>
                CreditCardValidator.Validate(cardNumber));
        }
    }
}