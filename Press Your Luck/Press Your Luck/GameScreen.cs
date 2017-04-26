/* Group Members: Clarence Williams and Rephael Edwards
 * Date: 10-6-2016
   Class: CMPS 4143
   Professor: Dr. Catherine Stringfellow
 * Description: This program allows you to play a version of the game
 * Press Your luck.
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Resources;
using System.Media;
using System.IO;


namespace Press_Your_Luck
{
    public partial class GameScreen : Form
    {
        //Variable declarations(name private data)
        private Database TriviaDatabase = new Database();
        private Player Player1 = new Player();
        private Player Player2 = new Player();
        private Random j = new Random();
        private Random n = new Random();
        private int nInt;
        private int centerInt;
        private int randQues;
        private int p1_spins, p2_spins, p1_money, p2_money;
        private int noOfQues = 0;
        private string tempAns;
        private bool isCorrect;
        private SoundPlayer gameSound = new SoundPlayer("..\\..\\song.wav");
        private SoundPlayer boardSound = new SoundPlayer("..\\..\\BoardSound.wav");
        private SoundPlayer whammySound = new SoundPlayer("..\\..\\whammy.wav");
        // timer variable
        private System.Timers.Timer picTime = new System.Timers.Timer();

             
        //Purpose: To initialize the game form
        //Requires: A game form
        //Returns: The game screen
        public GameScreen()
        {
            InitializeComponent();
            string textboxInfo;
            Spin_button.Enabled = false;
            Stop_button.Enabled = false;
            Next_button.Enabled = false;
            Submit_button.Enabled = false;
            P1_passSpins.Enabled = false;
            P2_passSpins.Enabled = false;

            // calls a function to read in the questions 
            //and answers from the text
            TriviaDatabase.getTrivia();

            //clear all output boxes 
            question_Box.Text = string.Empty;
            Answer_box.Text = string.Empty;
            Check_ans_box.Text = string.Empty;
            spinsP1.Text = string.Empty;
            spinsP2.Text = string.Empty;
            moneyP1.Text = string.Empty;
            moneyP2.Text = string.Empty;
            gameSound.Stop();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        //Purpose: To call needed functions on start.
        //Requires: the start button to be clicked
        //Returns: none
        private void Start_button_Click(object sender, EventArgs e)
        {
           Next_button.Enabled = true;
           Submit_button.Enabled = true;
           if (noOfQues < 3)
                Check_ans_box.Text = ("Player1: Answer a question");
            else
                Check_ans_box.Text = ("Player2: Answer a question");
            randQues = j.Next(0, (TriviaDatabase.getLength() - 1));
            question_Box.Text = TriviaDatabase.getQuestion(randQues);
            noOfQues++;

           if (noOfQues > 5)
            {
                Spin_button.Enabled = true;
                Stop_button.Enabled = true;
            }
        }

        //Purpose: To create a timer.
        //Requires:none
        //Returns: A timer which can be used with an event.
        private void TimeEvent(Object myObject, EventArgs myEventArgs)
        {
            
            picTime.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            picTime.Interval = 500;
            picTime.Enabled = true;
        }

        //Purpose: To change the pictures based on a timer
        //Requires:The object that the timer will be applied to.
        //Returns:none
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
                // Call the function to alternate the images for each box.
                ChangePic(pictureBox1, ref nInt);
                ChangePic(pictureBox2, ref nInt);
                ChangePic(pictureBox3, ref nInt);
                ChangePic(pictureBox4, ref nInt);
                ChangePic(pictureBox5, ref nInt);
                ChangePic(pictureBox6, ref nInt);
                ChangePic(pictureBox7, ref nInt);
                ChangePic(pictureBox8, ref nInt);
                ChangePic(pictureBox9, ref nInt);
                ChangePic(pictureBox10, ref nInt);
                ChangePic(Center_Box, ref centerInt);
        }

        //Purpose:To randomly generate a number and assign the picture filepath.
        //Requires: Picture boxes
        //Returns:none
        public void ChangePic(PictureBox pic, ref int temp)
        {
            temp = n.Next(1, 14);
            pic.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\pressPic" + temp + ".png");
        }

        //Purpose: To stop certain procsses in the game.
        //Requires: the objects.
        //Returns: none
        private void Stop_button_Click(object sender, EventArgs e)
        {
            // stop the pictures from spinning
            picTime.Stop();
            boardSound.Stop();
            // call the function to process the # in centerInt
            // if the number of spins for the player is not = 0
            // then that player spins
            if (!Player1.isOutOfSpins())
            {
                picOptions(Player1);
            }
            else if (!Player2.isOutOfSpins())
                picOptions(Player2);

            if(!Player1.isOutOfSpins())
            {
                Player1.decSpins();
                p1_spins = Player1.getSpins();
                p2_spins = Player2.getSpins();
                spinsP1.Text = p1_spins.ToString();
                spinsP2.Text = p2_spins.ToString();
                p1_money = Player1.getMoney();
                p2_money = Player2.getMoney();
                moneyP1.Text = p1_money.ToString();
                moneyP2.Text = p2_money.ToString();
            }
            else if(!Player2.isOutOfSpins())
            {
                Player2.decSpins();
                p1_spins = Player1.getSpins();
                p2_spins = Player2.getSpins();
                spinsP1.Text = p1_spins.ToString();
                spinsP2.Text = p2_spins.ToString();
                p1_money = Player1.getMoney();
                p2_money = Player2.getMoney();
                moneyP1.Text = p1_money.ToString();
                moneyP2.Text = p2_money.ToString();
            }

            if ((Player1.isOutOfSpins()) && (Player2.isOutOfSpins()))
            {
                boardSound.Stop();
                CheckWinner();
            }
        }

        //Purpose: Adjusts the Player's data based on the picture number
        //Requires: The instance of the player who is playing at the time 
        //Returns: nothing
        private void picOptions(Player temp)
        {
            // switch statement to determine what adjustments to make to 
            // the player's money or amount of spins based on the pic in the
            // center box.
            switch (centerInt)
            {
                case 1:
                    temp.setMoney(4500);
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 2:
                    temp.setMoney(5000);
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 3:
                    temp.whammy();
                    whammySound.Play();
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 4:
                    temp.setMoney(750);
                    temp.setSpins(1);
                    p1_spins = Player1.getSpins();
                    p2_spins = Player2.getSpins();
                    spinsP1.Text = p1_spins.ToString();
                    spinsP2.Text = p2_spins.ToString();
                    break;
                case 5:
                    temp.setMoney(500);
                    temp.setSpins(1);
                    p1_spins = Player1.getSpins();
                    p2_spins = Player2.getSpins();
                    spinsP1.Text = p1_spins.ToString();
                    spinsP2.Text = p2_spins.ToString();
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 6:
                    temp.setMoney(5000);
                    temp.setSpins(1);
                    p1_spins = Player1.getSpins();
                    p2_spins = Player2.getSpins();
                    spinsP1.Text = p1_spins.ToString();
                    spinsP2.Text = p2_spins.ToString();
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 7:
                    temp.setMoney(1750);
                    temp.setSpins(1);
                    p1_spins = Player1.getSpins();
                    p2_spins = Player2.getSpins();
                    spinsP1.Text = p1_spins.ToString();
                    spinsP2.Text = p2_spins.ToString();
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 8:
                    temp.setMoney(-25000);
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 9:
                    temp.setMoney(5);
                    break;
                case 10:
                    temp.setMoney(8000);
                    temp.setSpins(1);
                    p1_spins = Player1.getSpins();
                    p2_spins = Player2.getSpins();
                    spinsP1.Text = p1_spins.ToString();
                    spinsP2.Text = p2_spins.ToString();
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 11:
                    temp.whammy();
                    whammySound.Play();
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 12:
                    temp.setMoney(900);
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 13:
                    temp.setMoney(4000);
                    temp.setSpins(1);
                    p1_spins = Player1.getSpins();
                    p2_spins = Player2.getSpins();
                    spinsP1.Text = p1_spins.ToString();
                    spinsP2.Text = p2_spins.ToString();
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                case 14:
                    temp.setMoney(3500);
                    p1_money = Player1.getMoney();
                    p2_money = Player2.getMoney();
                    moneyP1.Text = p1_money.ToString();
                    moneyP2.Text = p2_money.ToString();
                    break;
                default:
                    break;
            }
        }

        //Purpose: To process the events called by clicking the submit button
        //Requires: an object
        //Returns: nothing
        private void Submit_button_Click(object sender, EventArgs e)
        {
            tempAns = Answer_box.Text.ToUpper();
            isCorrect = TriviaDatabase.isAns(tempAns, randQues);
            if (isCorrect == true)
            {
                if (noOfQues <= 3)
                    Player1.setSpins(3);
                else
                    Player2.setSpins(3);
                Check_ans_box.Text = ("Correct");
                p1_spins = Player1.getSpins();
                p2_spins = Player2.getSpins();
                spinsP1.Text = p1_spins.ToString();
                spinsP2.Text = p2_spins.ToString();
                p1_money = Player1.getMoney();
                p2_money = Player2.getMoney();
                moneyP1.Text = p1_money.ToString();
                moneyP2.Text = p2_money.ToString();
            }
            else
                Check_ans_box.Text = ("Wrong. The answer is: " + TriviaDatabase.getAnswer(randQues));
        }

        //Purpose:To rotate the images for the spin.
        //Requires: an object
        //Returns: nothing
        private void Spin_button_Click(object sender, EventArgs e)
        {
            // play the song
            question_Box.Clear();
            whammySound.Stop();
            boardSound.Load();
            boardSound.PlayLooping();

            if (!Player1.isOutOfSpins())
            {
                Check_ans_box.Text = ("Player1 is spinning now");
                TimeEvent(Spin_button, e);
            }

            else if (!Player2.isOutOfSpins())
            {
                Check_ans_box.Text = ("Player2 is spinning now");
                TimeEvent(Spin_button, e);
            }
            else if ((Player1.isOutOfSpins()) && (Player2.isOutOfSpins()))
            {
                boardSound.Stop();
                CheckWinner();
            }
        }

        //Purpose: To process the events called by clicking the Next button
        //Requires: an object
        //Returns: nothing
        private void Next_button_Click(object sender, EventArgs e)
        {
            if (noOfQues < 6)
            {
                Answer_box.Text = String.Empty;
                Check_ans_box.Text = String.Empty;
                if (noOfQues < 3)
                    Check_ans_box.Text = ("Player1: Answer a question");
                else
                    Check_ans_box.Text = ("Player2: Answer a question");
                ChooseRandomQuestion();
                noOfQues++;
            }
            else
            {
                Next_button.Enabled = false;
                Submit_button.Enabled = false;
                Start_button.Enabled = false;
                if (!Player1.isOutOfSpins()) 
                {
                    Check_ans_box.Text = ("Player 1 to Spin");
                }
                 else if (!Player2.isOutOfSpins())
                {
                    Check_ans_box.Text = ("Player 2 to Spin");
                }
                else
                {
                    Start_button.Enabled = true;
                    Next_button.Enabled = false;
                    Submit_button.Enabled = false;
                    Spin_button.Enabled = false;
                    Stop_button.Enabled = false;
                    P1_passSpins.Enabled = false;
                    P2_passSpins.Enabled = false;
                    Check_ans_box.Text = ("Neither Player has spins. GAME OVER!");
                    question_Box.Clear();
                    Answer_box.Clear();
                }
            }
            if (noOfQues == 6)
            {
                Spin_button.Enabled = true;
                Stop_button.Enabled = true;
            }
        }

        //Purpose: To process the events called by clicking the Quit button
        //Requires: an object
        //Returns: nothing
        private void Quit_Click(object sender, EventArgs e)
        {
            boardSound.Stop();
            gameSound.Stop();
            whammySound.Stop();
            this.Close();
        }

        private void P1_passSpins_Click(object sender, EventArgs e)
        {
            Player2.setSpins(Player1.getSpins());
            Player1.clearSpins();
            p1_spins = Player1.getSpins();
            p2_spins = Player2.getSpins();
            spinsP1.Text = p1_spins.ToString();
            spinsP2.Text = p2_spins.ToString();
        }

        private void P2_passSpins_Click(object sender, EventArgs e)
        {
            Player1.setSpins(Player2.getSpins());
            Player2.clearSpins();
            p1_spins = Player1.getSpins();
            p2_spins = Player2.getSpins();
            spinsP1.Text = p1_spins.ToString();
            spinsP2.Text = p2_spins.ToString();
        }

        private void ChooseRandomQuestion()
        {
            randQues = j.Next(0, (TriviaDatabase.getLength() - 1));
            question_Box.Text = TriviaDatabase.getQuestion(randQues);
        }

        private void CheckWinner()
        {
            string congratulations;
            if (Player1.isRicher(Player2))
            {
                congratulations = ("Congratulaions!! \n");
                congratulations += (" \n");
                congratulations += ("Player1 has won!  \n Game Over");
                Check_ans_box.Text = congratulations;
            }
            else if (Player2.isRicher(Player1))
            {
                congratulations = ("Congratulaions!! \n");
                congratulations += (" \n");
                congratulations += ("Player2 has won! \n Game Over");
                Check_ans_box.Text = congratulations;
            }
            else if ((Player1.getMoney()) == (Player2.getMoney()))
            {
                congratulations = ("Congratulaions!! \n");
                congratulations += (" \n");
                congratulations += ("It's a Tie! \n Game Over");
                Check_ans_box.Text = congratulations;
            }
            else // condition if both players have zero 
            {
                congratulations = ("You Both Lose!!  \n Game Over \n");
                Check_ans_box.Text = congratulations;
            }
            //MessageBox.Show("Please Click Quit");
            Start_button.Enabled = true;
        }

   
    }

}

