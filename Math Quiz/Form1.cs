using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addEnd1;
        int addEnd2;
        int subEnd1;
        int subEnd2;
        int mulEnd1;
        int mulEnd2;
        int divEnd1;
        int divEnd2;

        int timeLeft;

        public void startQuiz()
        {
            addEnd1 = randomizer.Next(51);
            addEnd2 = randomizer.Next(51);

            plusLeftLabel.Text = addEnd1.ToString();
            plusRightLabel.Text = addEnd2.ToString();

            sum.Value = 0;

            subEnd1 = randomizer.Next(1, 101);
            subEnd2 = randomizer.Next(1, subEnd1);

            minusLeftLabel.Text = subEnd1.ToString();
            minusRightLabel.Text = subEnd2.ToString();

            difference.Value = 0;

            mulEnd1 = randomizer.Next(2, 11);
            mulEnd2 = randomizer.Next(2, 11);

            timesLeftLabel.Text = mulEnd1.ToString();
            timesRightLabel.Text = mulEnd2.ToString();

            product.Value = 0;

            divEnd1 = randomizer.Next(2, 11);
            int temp = randomizer.Next(2, 11);
            divEnd2 = divEnd1 * temp;

            byLeftLabel.Text = divEnd2.ToString();
            byRightLabel.Text = divEnd1.ToString();

            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private bool checkAnswer()
        {
            if((addEnd1+addEnd2 == sum.Value)
                &&(subEnd1-subEnd2 == difference.Value)
                &&(mulEnd1*mulEnd2==product.Value)
                &&(divEnd2/divEnd1==quotient.Value))
                return true;

            return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            startQuiz();
            startBtn.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startBtn.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if(timeLeft < 6)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addEnd1 + addEnd2;
                difference.Value = subEnd1 - subEnd2;
                product.Value = mulEnd1 * mulEnd2;
                quotient.Value = divEnd2 / divEnd1;
                startBtn.Enabled = true;
                timeLabel.BackColor = DefaultBackColor;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
