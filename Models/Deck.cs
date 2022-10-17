using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DeckOfCards.Models
{
    class Deck
    {
        public List<Card> Cards = new List<Card>();

        public Deck()
        {
            foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
            {
                foreach (Card.CardValue cardValue in Enum.GetValues(typeof(Card.CardValue)))
                {
                    Cards.Add(new Card(suit, cardValue));
                }
            }
        }

        public void DealOut(int numberOfHands, int numberOfCardsPerHand)
        {
            if (numberOfHands * numberOfCardsPerHand > 52)
            {
                Console.WriteLine("The number of cards needed to be dealt exceeds the number of cards in the deck");
            }
            else
            {
                // Deal out the cards to each hand
                Card[,] hands = new Card[numberOfHands, numberOfCardsPerHand];
                int currentCardIndex = 0;

                for (int i = 0; i < numberOfCardsPerHand; i++)
                {
                    for (int j = 0; j < numberOfHands; j++)
                    {
                        hands[j, i] = Cards[currentCardIndex];
                        currentCardIndex = currentCardIndex + 1;
                    }
                }

                // Show the hands that were dealt
                for (int i = 0; i < numberOfHands; i++)
                {
                    Console.Write("Hand " + (i + 1).ToString() + ": ");

                    for (int j = 0; j < numberOfCardsPerHand; j++)
                    {
                        Console.Write("[" + hands[i, j].Value.ToString() + " " +
                         hands[i, j].Suit.ToString() + "] ");
                    }

                    Console.WriteLine();
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            int maxCardCount = Cards.Count;

            for (int i =0; i<maxCardCount; i++)
            {
                int changeIndex = i + random.Next(maxCardCount - i);
                Swap(i, changeIndex);
            }
        }

        private void Swap(int index, int change)
        {
            Card holder = Cards[index];
            Cards[index] = Cards[change];
            Cards[change] = holder;
        }
    }
}
