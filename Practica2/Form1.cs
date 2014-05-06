using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2
{
    public partial class Form1 : Form
    {
        // Create a Random object to generate random numbers.
        Random randomizer = new Random();

        // These ints will store the numbers
        // for the addition problem.
        int addend1;
        int addend2;

        // This int will keep track of the time left.
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        public void iniciarQuiz() {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            suma.Value = 0;

            this.timeLeft = 30;
            this.timeLabel.Text = "30 segundos";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.iniciarQuiz();
            this.startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkearRespuesta())
            {
                timer1.Stop();
                MessageBox.Show("Todas las respuestas correctas!", "Completado!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " segundos";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Tiempo agotado";
                MessageBox.Show("No terminaste a tiempo", "Fail!");
                suma.Value = addend1 + addend2;
                this.startButton.Enabled = true;
            }
        }

        private bool checkearRespuesta()
        {
            if (addend1 + addend2 == suma.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void suma_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
