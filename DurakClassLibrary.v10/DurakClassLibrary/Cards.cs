/*
 * Authr Thais Stefanini
 * 
 * Class created following the instruction on "Adding a Cards Collection to CardLib" page 244 of the book.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public class Cards : List<Card>, ICloneable
    {
        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                //targetCards[index] = this[index];
                targetCards.Add(this[index]);
            }
        }

        /// <summary>
        /// Creates a clone of the provided object
        /// </summary>
        /// <returns>returns the newly created cloned object</returns>
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }

    }
}