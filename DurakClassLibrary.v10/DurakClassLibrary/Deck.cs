/*
 * Author Thais Stefanini
 *        Dhara Savaliya 
 * 
 * Class created following the instruction on EXAMPLE APPLICATION page 224 of the book.
 */

using System;

namespace DurakClassLibrary
{
    public class Deck : ICloneable
    {
        //private Card[] cards;
        protected Cards cards = new Cards();
        private int numberOfCards = 0;

        protected int NumberOfCards { get => numberOfCards; set => numberOfCards = value; }

        // Constructors
        public Deck(Cards newCards)
        {
            cards = newCards;
            numberOfCards = cards.Count;
        }

        public Deck()
        {
        }

        
        public Deck(GameMode gameMode)
        {
            // Creating a switch to allow user to select the game they wants to play
            switch (gameMode)
            {
                // If standard is selected, it will create a regular deck with 52 cards
                case GameMode.Standard:
                    {
                        // for loop to run for four suit types
                        for (int suitVal = 0; suitVal < 4; suitVal++)
                        {
                            // for loop to run for the rank from deuce to ace(Higher) card
                            for (int rankVal = 2; rankVal < 15; rankVal++)
                            {
                                // adding the card with specific suit and rant to myDeck object.
                                cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                            }
                        }
                        numberOfCards = cards.Count;
                        break;
                    }
                // If Durak is selected, it will create a deck with 30 cards 
                // with specific cards seleced according to game rule
                case GameMode.Durak:
                    {
                        // for loop to run for four suit types
                        for (int suitVal = 0; suitVal < 4; suitVal++)
                        {
                            // Adds the cards with starting rank of 8 till ace
                            for (int rankVal = 6; rankVal < 15; rankVal++)
                            {
                                // Adding a passed suit with other rankss
                                cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                            } // for loop ends here
                        }
                        numberOfCards = cards.Count;
                        break;
                    }
            } // Switch case ends 
        } // GameMode method ends here


        /// <summary>
        /// Accessor for numberOfCards
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfCards()
        {
            return numberOfCards;
        }

        public Card GetCard(int cardNum = 0)
        {
            if (cardNum >= 0 && cardNum <= cards.Count - 1)
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardnum", cardNum,
                        "value must be between 0 and " + (cards.Count - 1) + "."));
        }
        /// <summary>
        /// Draw a card from the deck and remove it from the deck
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public Card DrawCard(int cardNum = 0)
        {
            if (cardNum >= 0 && cardNum <= cards.Count - 1)
            {
                if (numberOfCards > 0)
                {
                    Card drawCard = cards[cardNum];
                    cards.RemoveAt(cardNum);
                    numberOfCards = cards.Count;

                    return drawCard;
                }
                else
                    throw new NoCardsToReturnException();
                
            }
            else
                throw (new System.ArgumentOutOfRangeException("cardnum", cardNum,
                        "value must be between 0 and " + (cards.Count - 1) + "."));
        }


        /// <summary>
        /// gets the cards for the myDeck object
        /// </summary>
        /// <returns>Returns the Cards object</returns>
        public Cards GetCards()
        {
            return cards;
        }

        public void Shuffle()
        {
            // Creating another clone of myDeck to change the card location and remove the card with successful attempt 
            Deck newDeck = new Deck(cards.Clone() as Cards);

            // used to pick a random number
            int randomPosition = 0;

            // This clears the myDeck so we can put the new card to it
            cards.Clear();

            // Getting a random number
            Random randomNumber = new Random();

            // for loop till the cards object is not empty.
            for (int i = newDeck.GetCards().Count; i > 0; i--)
            {
                // picking a random position from the given deck
                randomPosition = randomNumber.Next(newDeck.GetCards().Count);
                // Adds the random location number card to myDeck 
                cards.Add(newDeck.GetCards()[randomPosition]);
                // Remove the moved object from the base object to avoid repetation
                newDeck.GetCards().RemoveAt(randomPosition);
            }
        }

        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        /// <summary>
        /// Sort the deck
        /// </summary>
        public void Sort()
        {
            cards.Sort();
        }

    }
}