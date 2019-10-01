using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakClassLibrary;

namespace DurakUI
{
    public partial class frmLetsPlayDurak : MyForm
    {
        public frmLetsPlayDurak()
        {
            InitializeComponent();
            txtName.Text = Player.RandomName();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmGameSetting gameSetting = new frmGameSetting();
            gameSetting.Show();
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            playerName = txtName.Text;
            // MessageBox.Show(playerName);
            frmPlayTime PlayTime = new frmPlayTime();
            PlayTime.Show();
        }

        private void frmLetsPlayDurak_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
