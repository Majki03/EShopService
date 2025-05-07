using Xunit;
using EShop.Application;
using System.Collections.Generic;

namespace EShop.Application.Tests;

public class CardValidatorTests
{
    [Theory]
    [MemberData(nameof(CardValidationData))]
    public void ValidateCard_ReturnsExpected(string cardNumber, bool expected)
    {
        bool result = CardValidator.ValidateCard(cardNumber);
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> CardValidationData =>
        new List<object[]>
        {
            new object[] { "4024 0071 6540 1778", true },
            new object[] { "4532-2080-2150-4434", true },
            new object[] { "4111 1111 1111 1111", true },
            new object[] { "4111 1111 1111 1110", false },
            new object[] { "abcdefg1234567", false },
            new object[] { "123456", false },
            new object[] { "", false },
            new object[] { "0000 0000 0000 0000", false }
        };
}