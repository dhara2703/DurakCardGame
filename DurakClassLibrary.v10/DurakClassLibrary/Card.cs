using System;
using System.Drawing;

namespace DurakClassLibrary
{
    public class Card : ICloneable, IComparable
    {


        #region FIELDS AND PROPERRTIES

        /// <summary>
        /// Suit Property
        /// Used to set or get the Card Suit
        /// </summary>
        //protected Suit mySuit;
        protected Suit mySuit;
        public Suit CardSuit
        {
            get { return mySuit; } // return the suit
            set { mySuit = value; } // set the suit
        }

        /// <summary>
        /// Rank Property
        /// Used to set or get the Card Rank
        /// </summary>
        protected Rank myRank;
        public Rank CardRank
        {
            get { return myRank; } // get the rank
            set { myRank = value; } // set the rank
        }



        /// <summary>
        /// FaceUp Property
        /// Used to set or get whether the card is face up.
        /// Set to false by default.
        /// </summary>
        protected bool faceUp = false;
        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }
        }

        #endregion


        #region  Constructors

        ///// <summary>
        ///// An empty constructor
        ///// </summary>
        //public Card()
        //{
        //}

        /// <summary>
        /// The parameterized constructor which sets the suit and rank
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="rank"></param>
        public Card(Suit suit = Suit.Hearts, Rank rank = Rank.Ace)
        {
            this.mySuit = suit;
            this.myRank = rank;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a shallow copy of the current System.Object.
        /// </summary>
        /// <returns>A shallow copy of the current System.Object.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Overrides the ToString method and displays a readable fomat for the card object.
        /// </summary>
        /// <returns>The string format with presentable format</returns>
        public override string ToString()
        {
            string cardString; // holds the playing card name.
            // if the card is face up
            if (faceUp)
            {
                // if the card is a Joker
                if (myRank == Rank.Joker)
                {
                    // set card name string to {Red|Black} Joker
                    // if the suit is black
                    if (mySuit == Suit.Clubs || mySuit == Suit.Spades)
                    {
                        // set the name string to black joker
                        cardString = "Joker_Black";
                    }
                    else // the suit must be red
                    {
                        // set the name string to red joker
                        cardString = "Joker_Red";
                    }
                }
                // otherwise, the card is a face up but not a joker
                else
                {
                    // set the cand name string to {Rank} of {Suit}
                    cardString = myRank.ToString() + " of " + mySuit.ToString();
                }
            }
            // otherwise, the card is face down
            else
            {
                // set the card name to face down.
                cardString = "Face Down";
            }

            //return "The " + rank + " of " + suit;

            // return the appropriate card name string
            return cardString;

        }

        /// <summary>
        /// /// This will be used to compare the current object with the passed card object
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public override bool Equals(object card)
        {

            return this == (Card)card;
        }

        /// <summary>
        /// It returns the position of the card as integer
        /// </summary>
        /// <returns>INt for the position of the card</returns>
        public override int GetHashCode()
        {
            //return 13 * (int)suit + (int)rank; // Previously used

            return 13 * (int)this.mySuit + (int)this.myRank; // added more to verify whether the card is face up or not. 
        }


        /// <summary>
        /// GetCardImage
        /// Gets the image associated with the card from the resource file.
        /// </summary>
        /// <returns>an Image corresponding to the playing card.</returns>
        public Image GetCardImage()
        {
            string imageName; // the name of the image in the resources file
            Image cardImage; // holds the image
            // if the card is not face up
            if (!faceUp)
            {
                //set the image name to "Back"
                imageName = "Back"; // sets it to the image name for the back of a card
            }
            else if (myRank == Rank.Joker) // if the card is a joker
            {
                // if teh suit is black
                if (mySuit == Suit.Clubs || mySuit == Suit.Spades)
                {
                    // set the image to black joker
                    imageName = "Joker_Black";
                }
                else // the suit must be red
                {
                    // set the image to red joker
                    imageName = "Joker_Red";
                }
            }
            else // otherewise, the card is face up and not joker
            {
                // set the iamge name to {Suit}_{Rank}
                imageName = mySuit.ToString() + "_" + myRank.ToString(); // enumerations are handy!
            }
            // Set the image to the appropriate object we get from the resources file
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

            // return the image
            return cardImage;
        }


        /// <summary>
        /// DebugString
        /// Generates a string showing the state of the card object; useful for debug purposes
        /// </summary>
        /// <returns>a string showing the state of this card object</returns>
        public string DebugString()
        {   
            // This method is used to test the state of the card
            string cardState = (string)(myRank.ToString() + " of " + mySuit.ToString()).PadLeft(20);
            cardState += (string)((FaceUp) ? "(Face Up)" : "(Face Down)").PadLeft(12);
            //cardState += " Value: " + myValue.ToString().PadLeft(2); // As we are not focusing on card values we are skipping it. 
            //cardState += ((altValue != null) ? "/" + altValue.ToString() : "");
            return cardState;
        }


        /// <summary>
        /// Compare two cards
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>-1, 0, or 1</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                // throw an argument null exception.
                throw new ArgumentNullException("Unable to compare a Card to a null object.");
            }

            Card compareCard = obj as Card;    // If the object is not a Card, the code below will trhow an exception.

            //if (compareCard != null)
            //{
                // Compare based on the Rank first 
                double thisSort = (double)this.myRank + ((double)this.mySuit * 20);
                double compareCardSort = (double)compareCard.myRank + ((double)compareCard.mySuit * 20);
                // this return -1, 0, or 1
                return (thisSort.CompareTo(compareCardSort));
            //}
            //else
            //{
            //    throw new ArgumentException("Object being compared cannot be converted to a Card");
            //}
        } // End of CompareTo

        #endregion


        #region RELATIONAL OPERATORS

        /// <summary>
        /// This will be used to compare two objects are equal or not
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.mySuit == card2.mySuit) && (card1.myRank == card2.myRank);
        }

        /// <summary>
        /// This will be used to compare two objects by using equal operator and reverce the result to make it NOT EQUAL
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }



        /// <summary>
        /// This will be used to compare two objects by using greater than sign to check their grade. 
        /// If the suits are equal, it will check their ranks to find that is it greater than 
        /// this or not to return boolean   
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator >(Card card1, Card card2)
        {
            return (card1.myRank > card2.myRank);
        }

        /// <summary>
        /// This will be used to compare two objects by using less than sign to check their grade. 
        /// If the suits are equal, it will check their ranks to find that is it greater than 
        /// this or not to return boolean    
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns>A boolean variable</returns>
        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        /// <summary>
        /// This will be used to compare two objects by using greater than or equal to sign to check their grade. 
        /// If the suits are equal, it will check their ranks to find that is it greater than 
        /// this or not to return boolean   
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns>A Boolean variable</returns>
        public static bool operator >=(Card card1, Card card2)
        {
            return (card1.myRank >= card2.myRank);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns>A bool variable</returns>
        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

        #endregion





    }
}