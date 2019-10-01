using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DurakClassLibrary
{
    public class Table
    {
        private static Card trumpCard;
        private Cards discardPile = new Cards();
        private Cards attack = new Cards();
        private Cards defense = new Cards();

        public Deck deck;
        private static int attackCounter = 0;
        private static int defenseCounter = 0;

        HumanPlayer human;
        MachinePlayer computer;

        GameStage gameStage;

        public Card TrumpCard { get => trumpCard; }
        public GameStage GameStage { get => gameStage; set => gameStage = value; }
        public HumanPlayer Human { get => human; set => human = value; }
        public MachinePlayer Computer { get => computer; set => computer = value; }

        /// <summary>
        /// Create a standard table object
        /// </summary>
        public Table()
        {
            deck = new Deck(GameMode.Standard);
            deck.Shuffle();

            human = new HumanPlayer(DrawHand());    // Creates a human player and draw its first hand
            computer = new MachinePlayer(DrawHand());    // Creates a machine player and draw its first hand

        }

        /// <summary>
        /// Create a table object for a game mode
        /// </summary>
        public Table(GameMode game)
        {
            deck = new Deck(game);
            deck.Shuffle();
            trumpCard = deck.GetCard(deck.GetNumberOfCards() - 1);  //Must be -1 because its an index.

            human = new HumanPlayer(DrawHand());    // Creates a human player and draw its first hand
            computer = new MachinePlayer(DrawHand());    // Creates a machine player and draw its first hand

            // Randmly define the first attacker
            Random rand = new Random();     // Generate a random number
            if ((int)rand.Next() % 2 == 0)     // Check if random number is even
            {
                gameStage = GameStage.HumanAttack;
                //gameStage = GameStage.MachineAttack;
            }
            else
            {
                //gameStage = GameStage.MachineAttack;
                gameStage = GameStage.HumanAttack;
            }
        }

        /// <summary>
        /// Draw cards to the players hands
        /// </summary>
        /// <param name="numOfCards">Number of cards of the returned PlayerHand, will be 6 if no parameter submitted</param>
        /// <returns>a PlayerHand with the number of cards of the parameter</returns>
        public PlayerHand DrawHand(int numOfCards = 6)  // 6 is the basic number of cards for a Player Hand in a Durak game
        {
            PlayerHand myHand = new PlayerHand();
            for (int i = 0; i < numOfCards; i++)
            {
                try
                {
                    myHand.AddHandCard(DrawCard());
                }
                catch (NoCardsToReturnException)
                {
                    i = numOfCards;   // leave the loop

                    // Verify if I was able to draw at least one card
                    if (myHand.GetNumberOfCards() == 0)
                    {
                        // if myHand is empty, throw exception, otherwise just return myHand
                        throw new NoCardsToReturnException();
                    }
                }
                
            }
            return myHand;
        }

        /// <summary>
        /// Make an attack
        /// </summary>
        /// <param name="receiveCard"></param>
        /// <returns></returns>
        public bool MakeAttack(Player player, Card receiveCard)
        {
            Boolean cardIsOK = CheckAttack(receiveCard);

            if (cardIsOK)    // Make the attack only if card is valid
            {
                attack.Add(receiveCard);
                attackCounter++;

                player.Hand.PickHandCard(receiveCard);   // remove this card from the player hand
            } 

            return cardIsOK;

        }

        /// <summary>
        /// Check if attack is a valid card
        /// </summary>
        /// <param name="receiveCard"></param>
        /// <returns></returns>
        public bool CheckAttack(Card receiveCard)
        {
            bool cardIsOK = false;

            if (attackCounter != 0)  // validate card if it is not first attack of the round
            {
                foreach (Card c in attack)
                {
                    if (receiveCard.CardRank == c.CardRank)
                    {
                        cardIsOK = true;
                    }
                }
                foreach (Card c in defense)
                {
                    if (receiveCard.CardRank == c.CardRank)
                    {
                        cardIsOK = true;
                    }
                }
            }
            else    // First attack of the round, any card is OK
            {
                cardIsOK = true;
            }

            return cardIsOK;

        }

        /// <summary>
        /// Validate if the defense was able to win over the attack or not
        /// </summary>
        /// <returns>true if defense win over attack, and false it not</returns>
        public bool CheckDefense()
        {
            bool result = true;
            for (int i = 0; i < defense.Count; i++)    // validate all cards
            {
                if (attack[i].CardSuit == defense[i].CardSuit)     // if the cards has the same suit, check the greater rank
                {
                    if (attack[i] > defense[i])
                    {
                        // Attack won this round
                        result = false;
                        i = defense.Count;
                    }
                }
                else if (defense[i].CardSuit != trumpCard.CardSuit)    // check if defense is using a trump card
                {
                    // attack won this round
                    result = false;
                    i = defense.Count;
                }
            }
            // return true if defesen win over attack, and false it not
            return result;
        }

        /// <summary>
        /// Make a defense after the attack card
        /// </summary>
        /// <param name="receiveCard"></param>
        /// <returns>true if defense win over attack, and false it not</returns>
        public bool MakeDefense(Player player, Card receiveCard)
        {
            bool result = false;
            // Add card to the defense list and increment its counter
            defense.Add(receiveCard);
            defenseCounter++;

            if (CheckDefense())
            { 
                result = true;

                player.Hand.PickHandCard(receiveCard);   // remove this card from the player hand
            }
            else
            {
                //if defense is not valid, remove the card from the list and decrease the counter
                defense.Remove(receiveCard);
                defenseCounter--;
            }

            return result;
        }

        /// <summary>
        /// Reset the attack and defense counters
        /// </summary>
        public void Reset()
        {
            attackCounter = 0;
            defenseCounter = 0;

        }

        /// <summary>
        /// Clean the table for the next round
        /// </summary>
        /// <param name="defenseWonRound">true if defense won the round</param>
        /// <returns>The cards to be added to the defense hand, or return an empty Cards object</returns>
        public Cards EndRound(bool defenseWonRound)
        {
            Cards result = new Cards();

            if (defenseWonRound)
            {
                // The defender won this round, so the cards from the table goes to the discard pile
                foreach (Card c in defense)
                {
                    discardPile.Add(c);
                }

                foreach (Card c in attack)
                {
                    discardPile.Add(c);
                }

                defense = new Cards();   // remove all cards from the defense List
                attack = new Cards();   // remove all cards from the attack List
            }
            else    //The attacker is the winner of the round
            {
                // The cards from the table will be returned, to be added to the defender's hand
                foreach (Card c in attack)
                {
                    result.Add(c);
                }
                foreach (Card c in defense)
                {
                    result.Add(c);
                }

                defense = new Cards();   // remove all cards from the defense List
                attack = new Cards();   // remove all cards from the attack List
            }

            Reset();   // Reset counters for next round

            // Add cards to the player that is defending
            if (GameStage == GameStage.MachineDefense)
            {
                Computer.Hand.AddHandsCard(result);
            }
            else if (GameStage == GameStage.HumanDefense)
            {
                Human.Hand.AddHandsCard(result);
            }

            return result;

        }

        /// <summary>
        /// Identify the number of cards that this player need to receive, draw those cards from the deck and add it to the player hand, 
        /// also return those cards so they can be used to update the screen
        /// </summary>
        /// <param name="player">Player that I want to check if need more cards on hand</param>
        public void CompletePlayerHand(Player player)
        {
            int numberOfCards = 6 - player.GetNumberOfCardsOnHand();  // 6 is the basic number of cards on hand on a Durak game

            // If the player has less then 6 cards, try draw more cards to the player
            if (numberOfCards > 0)
            {
                player.Hand.AddHandsCard(DrawHand(numberOfCards));   // add the cards to the player hand
            }
        }

        /// <summary>
        /// Draw a card from the deck
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns>a Card</returns>
        public Card DrawCard(int cardPosition = 0)
        {
            Card returnCard = deck.DrawCard(cardPosition);

            if (deck.GetNumberOfCards() == 1)
            {
                if (this.EmptydDeck != null)
                    this.EmptydDeck((object)this, new EventArgs());
            }
            if (deck.GetNumberOfCards() == 0)
            {
                if (this.NoTrump != null)
                    this.NoTrump((object)this, new EventArgs());
            }

            return returnCard;
        }


        /// <summary>
        /// Reset the attack and defense counters
        /// </summary>
        public static Suit? GetTrumpSuit()
        {
            return trumpCard.CardSuit;

        }


        /// <summary>
        /// Return the hand of the human player
        /// </summary>
        public PlayerHand GetHumanHand()
        {
            return human.Hand;
        }


        /// <summary>
        /// Return the hand of the computer player
        /// </summary>
        public PlayerHand GetMachineHand()
        {
            return computer.Hand;
        }

        /// <summary>
        /// Define a good card from the Machine hand, and make the attack
        /// </summary>
        /// <returns>The card of the attack, to update images on screen</returns>
        public Card MachineAttack()
        {
            Card lowestRankCardOK = new Card(Suit.Spades, Rank.Ace);  // Ace of Spades is the highest card number, in our enumerations
            bool foundOKCard = false;
            int counter = 0;

            foreach (Card c in computer.GetCards())
            {
                // Look for the lowest card that is not a trump
                if (c.CardSuit != Table.GetTrumpSuit())
                {
                    counter++;
                    if (c.CardRank <= lowestRankCardOK.CardRank)
                    {
                        // Check if this is a valid attack
                        if(CheckAttack(c))
                        {
                            lowestRankCardOK = c;
                            foundOKCard = true;
                        }
                    }
                }
            }

            // If all cards are trumps, return the lowest trump card
            if (counter == 0)
            {
                foreach (Card c in computer.GetCards())
                {
                    if (c.CardRank <= lowestRankCardOK.CardRank)
                    {
                        // Check if this is a valid attack
                        if (CheckAttack(c))
                        {
                            lowestRankCardOK = c;
                            foundOKCard = true;
                        }
                    }
                }
            }

            if (foundOKCard)
            {
                // If found a good card, make an attack with it
                MakeAttack(Computer, lowestRankCardOK);
            }
            else
            {
                // If there is no good card on hand, throw exception
                throw new NoOKCardException();
            }

            return lowestRankCardOK;
        }

        /// <summary>
        /// Define a good card from the Machine hand, and make the defense
        /// </summary>
        /// <returns>The card of the defense, to update images on screen</returns>
        public Card MachineDefense(Card attackCard)
        {
            Card lowestRankCardOK = new Card(Suit.Spades, Rank.Ace);  // Ace of Spades is the highest card number, in our enumerations
            bool foundOKCard = false;

            foreach (Card c in computer.GetCards())
            {
                // Look for the lowest card that is the same suit of the attack card, and the lowest rank grater than the attack card
                if (c.CardSuit == attackCard.CardSuit)
                {
                    if (c.CardRank > attackCard.CardRank && 
                        c.CardRank <= lowestRankCardOK.CardRank)
                    {
                        lowestRankCardOK = c;
                        foundOKCard = true;
                    }
                }
            }

            // If there is no good card with the same suit of the attack, check for the trumps cards (if the attack card is not a from trump suit)
            if (!foundOKCard && attackCard.CardSuit != trumpCard.CardSuit)
            {
                foreach (Card c in computer.GetCards())
                {
                    if (c.CardSuit == trumpCard.CardSuit)
                    {
                        if (c.CardRank <= lowestRankCardOK.CardRank)
                        {
                            lowestRankCardOK = c;
                            foundOKCard = true;
                        }
                    }
                }
            }

            if (foundOKCard)
            {
                // If found a good card, make an attack with it
                MakeDefense(Computer, lowestRankCardOK);
            }
            else
            {
                // If there is no good card on hand, throw exception
                throw new NoOKCardException();
            }

            return lowestRankCardOK;
        }

        /// <summary>
        /// An event the client program can handle when the deck is empty
        /// </summary>
        public event EventHandler EmptydDeck;

        /// <summary>
        /// An event the client program can handle when the trump card has being draw
        /// </summary>
        public event EventHandler NoTrump;

    }


    public enum GameStage
    {
        HumanAttack,
        MachineDefense,
        MachineAttack,
        HumanDefense
    }
}
