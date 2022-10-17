using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Models
{
    class Card
    {
        public Suits Suit { private set; get; }
        public CardValue Value { private set; get; }

        public enum Suits
        {
            DIAMONDS,
            CLUBS,
            HEARTS,
            SPADES
        }

        public enum CardValue
        {
            ACE,
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING
        }

        public Card(Suits suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
