using EluciusFTW.CardGames.Core.Cards.French;
using EluciusFTW.CardGames.Core.Cards.French.Extensions;
using FluentAssertions;
using Xunit;

namespace EluciusFTW.CardGames.Core.Tests
{
    public class SerializationTests
    {
        [Theory]
        [InlineData(Suit.Hearts, Symbol.Deuce, "2h")]
        [InlineData(Suit.Hearts, Symbol.Jack, "Jh")]
        [InlineData(Suit.Spades, Symbol.Ace, "As")]
        [InlineData(Suit.Clubs, Symbol.King, "Kc")]
        [InlineData(Suit.Diamonds, Symbol.Ten, "Td")]
        public void Serializes_Correctly(Suit suit, Symbol symbol, string expected)
        {
            var label = new Card(suit, symbol).ToShortString();

            label.Should().Be(expected);
        }

        [Theory]
        [InlineData("3h", Suit.Hearts, Symbol.Three)]
        [InlineData("8s", Suit.Spades, Symbol.Eight)]
        [InlineData("Kc", Suit.Clubs, Symbol.King)]
        public void Deserializes_Correctly(string expression, Suit expectedSuit, Symbol expectedSymbol)
        {
            var card = expression.ToCard();
            
            card.Suit.Should().Be(expectedSuit);
            card.Symbol.Should().Be(expectedSymbol);
        }
    }
}
