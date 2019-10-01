using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DurakClassLibrary;
using TheCardBox;

namespace DurakUI
{
    public class MyForm : Form
    {
        protected static string playerName = Player.RandomName(4);
        protected static int deckSize = 36;
        protected static Image pictureColor = (new Card()).GetCardImage();

    }
}
