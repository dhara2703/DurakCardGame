using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakUI
{
    public partial class frmGameSetting : MyForm
    {
        public frmGameSetting()
        {
            InitializeComponent();
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            if (radioButton36Deck.Checked == true)
            {
                deckSize = 36;
            }
            else if (radioButton52Deck.Checked == true)
            {
                deckSize = 52;
            }

            if (radioButtonRed.Checked == true)
            {
                pictureColor = pictureBoxRed.Image;
            }
            else if (radioButtonBlue.Checked == true)
            {
                pictureColor = pictureBoxBlue.Image;
            }
            else if (radioButtonYellow.Checked == true)
            {
                pictureColor = pictureBoxYellow.Image;
            }
            else if (radioButtonGreen.Checked == true)
            {
                pictureColor = pictureBoxGreen.Image;
            }
            else if (radioButtonGrey.Checked == true)
            {
                pictureColor = pictureBoxGrey.Image;
            }

            //MessageBox.Show(deckSize);
            //MessageBox.Show(pictureColor);
            frmPlayTime PlayTime = new frmPlayTime();
            PlayTime.Show();
            this.Hide();
        }
    }
}
