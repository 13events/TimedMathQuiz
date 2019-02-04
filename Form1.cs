using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {
        //create a Random object to create random numbers.
        Random randomizer = new Random();

        //store variables form the addition problem
        int addend1;
        int addend2;

        //keeps track of remaining time.
        int timeLeft;

        //start the quiz by filling in all the problems 
        //and starting the time.
        public void StartTheQuiz()
        {
            //fill in the addition problem


            //generate two random numbers to add.
            //store numbers in variables addend1 and addend2
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //convert random numbers to strings so we can store
            //them in plusLeftLabel and plusRightLabel
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //make sure to set sum button control value to zero
            sum.Value = 0;

            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();


        }


        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (CheckAnswers())
            {
                //if check answers returns TRUE, stop the time.
                //and show message box.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congradulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //display new time left by updating time label. 
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " Seconds";

            } else
            {
                //if user ran out of time, stop the timer.
                //show a message box and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time is up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }

        //checks the answers to see if user got everything right.
        //Returns true if answers is correct, otherwise returns false.
        private bool CheckAnswers()
        {
            if(addend1 + addend2 == sum.Value)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
        
}
