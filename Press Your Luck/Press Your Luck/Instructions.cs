using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Press_Your_Luck
{
    public partial class Instructions : Form
    {
        private SoundPlayer beginningSound = new SoundPlayer("..\\..\\song.wav");
        public Instructions()
        {
            InitializeComponent();
            beginningSound.Play();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            GameScreen game = new GameScreen();
            game.Show();
            this.Hide();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About aboutScreen = new About();
            aboutScreen.Show();
        }
    }
}
