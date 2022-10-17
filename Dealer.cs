using DeckOfCards.Models;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * This is a simple card dealing program that has a few basic functionality.
 * The first thing it does is generate a standard deck of 52 cards, this is done on program startup.
 * All other functionality requires user input. The deal command requires two inputs, the number of hands
 * to deal and the number of cards per hand. Dealing does not remove any cards from the deck. Dealing
 * using the same two parameters twice in a row will show the exact same result. Shuffle will rearrange
 * the cards in the deck. Sort will return the deck back to its original order. Exit quits the program.
 * There is some basic error handling but it is not perfect. 
 */
namespace DeckOfCards
{
    public static class Dealer
    {
        const string commandsList = "Commands: Deal(number of hands, number of cards), Sort, Shuffle, Exit";
        public static void BuildDeck()
        {
            Deck deck = new Deck();
            
            Console.WriteLine("The Dealer has built deck sorted by number and suit.");
            
            while (true)
            {
                Console.WriteLine(commandsList);
                string userInput = Console.ReadLine();

                if (userInput.ToLower().Substring(0,4) == "deal")
                {
                    try
                    {
                        Tuple<int, int> handsAndCards = GetHandsAndCards(userInput);
                        deck.DealOut(handsAndCards.Item1, handsAndCards.Item2);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Improperly formatted deal command");
                    }
                    
                }
                else if (userInput.ToLower() == "sort")
                {
                    // I full acknowledge that this is cheating and not truly sorting.
                    deck = new Deck();
                    Console.WriteLine("Deck has been sorted back to the original order");
                }
                else if (userInput.ToLower() == "shuffle")
                {
                    deck.Shuffle();
                    Console.WriteLine("The deck has been shuffled.");
                }
                else if (userInput.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number or command entered.");
                }

                Console.WriteLine();
            }

            Environment.Exit(0);
        }

        private static Tuple<int, int> GetHandsAndCards(string userInput)
        {
            Tuple<int, int> result = null;
            
            string userParameters = userInput.Split('(', ')')[1];
            string[] convertParameters = userParameters.Split(',');

            if (convertParameters.Length == 2)
            {
                result = new Tuple<int, int>(Int32.Parse(convertParameters[0]), Int32.Parse(convertParameters[1]));
            }
            else
            {
                Console.WriteLine("Improper number of parameters");
            }
            
            return result;
        }
    }
}
