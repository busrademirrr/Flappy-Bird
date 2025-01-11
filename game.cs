using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird1
{

    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(keyisdown);
            this.KeyUp += new KeyEventHandler(keyisup);
            this.Load += new EventHandler(game_Load);
            timer.Tick += new EventHandler(timerEvent);

            ground.Controls.Add(label1);
            label1.Left = 20;
            label1.Top = 5;


            RestartGame();
        }


        int speed = 13;
        int gravity = 3;
        int score = 0;
        bool gameOver = false;
        Random rnd1 = new Random();

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void game_Load(object sender, EventArgs e)
        {

        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -12;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 12;
            }
            if (e.KeyCode== Keys.R && gameOver)
            {
                RestartGame();
            }
        }

        private void endGame()
        {
            timer.Stop();
            label1.Text += " Oyun Bitti:( Yeniden başlamak için R' ye basın.";
            gameOver = true;
            restartImage.Enabled = true;
            restartImage.Visible = true;
        }

        private void timerEvent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeBottom.Left -= speed;
            pipeTop.Left -= speed;
            label1.Text = "Skor:" + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left= rnd1.Next(700,1300);
                score++;
            }





            if (pipeTop.Left < -180)
            {
                pipeTop.Left = rnd1.Next(800,1400);
                score++;
            }

            if (bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -25)
            {
                endGame();
            }

            if (score > 6)
            {
                speed = 17;
            }
        }
        private void RestartGame()
        {
            gameOver = false;
            bird.Location= new Point(49,177);
            pipeTop.Left = 800;
            pipeBottom.Left = 1050;

            score = 0;
            speed = 13;
            label1.Text = "score:0";
            restartImage.Enabled = false;
            restartImage.Visible = false;
            timer.Start();
        }

        private void RestartClick(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}