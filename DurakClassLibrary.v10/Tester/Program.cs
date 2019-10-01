using DurakClassLibrary;
using System;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {// Using the GameMode class to set the game type Durak.   
            Deck DurakDeck = new Deck(GameMode.Durak);

            //Console.WriteLine("The Durak Game Deck is (Organized):");

            //DurakDeck.GetCards();

            //foreach (Card card in DurakDeck.GetCards())
            //{
            //    Console.WriteLine(card.ToString());
            //}

            

            //Console.WriteLine("\nThe Durak Game Deck is (Shuffled):");

            //DurakDeck.Shuffle();

            //foreach (Card card in DurakDeck.GetCards())
            //{
            //    Console.WriteLine(card.ToString());
            //}

            //Console.ReadKey();
            //Console.Clear();

            Console.WriteLine("\nCreate a new table");

            Table myTable = new Table();

            foreach (Card card in myTable.deck.GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.ReadKey();
            //Console.Clear();

            Console.WriteLine("\nCreate a new attack");


            for (int i = 1; i < 13;)
            {
                myTable.MakeAttack(DurakDeck.GetCard(i));
                i++;
                myTable.MakeDefense(DurakDeck.GetCard(i));
                i++;
            }


            Console.ReadKey();

            Console.WriteLine("\nCreating a new hand: ");

            PlayerHand myHand = new PlayerHand(DurakDeck.GetCards());
            myHand.Shuffle();
            foreach (Card card in myHand.GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nAfter sort: ");

            // HERE IS NOT WORKING
            //myHand.GetCards().Sort();

            foreach (Card card in myHand.GetCards())
            {
                Console.WriteLine(card.ToString());
            }


            Console.ReadKey();

        }
    }
}
