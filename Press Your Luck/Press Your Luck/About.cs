using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Press_Your_Luck
{
    public partial class About : Form
    {
        private string aboutInfo;
        public About()
        {
            InitializeComponent();
            showInfo();
        }

       private void showInfo()
        {
            // Game play information for the user
            aboutInfo = ("This game allows two players to collect spins");
            aboutInfo += (" by answering a series of trivia questions and");
            aboutInfo += (" then use the spins on a game board to win cash");
            aboutInfo += (" and prizes. The person who has the most cash");
            aboutInfo += (" at the end of the game wins. \n\nPress START to begin answering questions.");
            aboutInfo += (" Player 1 answers three questions first then Player 2 is asked three questions.");
            aboutInfo += (" \nWhen six questions have been answered,");
            aboutInfo += (" click the SPIN button to spin the gameboard.");
            aboutInfo += (" this is where players get the oppurtunity to");
            aboutInfo += (" win money. \n\nPlayer 1 spins first and then");
            aboutInfo += (" Player 2 spins afterwards. \n\nBE CAREFUL!! A whammy");
            aboutInfo += (" takes all of your money!");
            aboutRTextBox.Text = aboutInfo;
        }

        private void aboutCloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
