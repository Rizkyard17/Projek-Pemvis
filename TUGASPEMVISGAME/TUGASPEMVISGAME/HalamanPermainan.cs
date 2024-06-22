using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUGASPEMVISGAME
{
    public partial class HalamanPermainan : Form
    {

        bool goLeft;
        bool goRight;
        bool isGameOver;

        int score;
        int ballx;
        int bally;
        int playerSpeed;


        Random rnd = new Random();


        public HalamanPermainan()
        {
            InitializeComponent();

            setupGame();
        }

        private void setupGame()
        {
            score = 0;
            ballx = 10;
            bally = 10;
            playerSpeed = 15;
            skor.Text = "Score : " + score;

            Waktu.Start();

            foreach(Control x in this.Controls)
            {

            }

        }


        private void gameOver(string message)
        {
            isGameOver = true;

            skor.Text = "Score : "+ score + " " + message;

            // Kembali ke form HalamanMasuk
            HalamanMasuk halamanMasuk = new HalamanMasuk();
            halamanMasuk.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HalamanPermainan_Load(object sender, EventArgs e)
        {

        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            skor.Text = "Score : " + score;

            if(goLeft == true && batang.Left > 0)
            {
                batang.Left -= playerSpeed;
            }

            if(goRight == true && batang.Right < 1450)
            {
                batang.Left += playerSpeed;
            }

            bola.Left += ballx;
            bola.Top += bally;

            if (bola.Left < 0 || bola.Left > 1390)
            {
                ballx = -ballx;
            }
            if (bola.Top < 0 )
            {
                bally = -bally;
            }
            if (bola.Bounds.IntersectsWith(batang.Bounds))
            {
                bally = rnd.Next(10, 15) * -1;

                if (ballx < 0)
                {
                    ballx = rnd.Next(10, 15) * -1;
                }
                else
                {
                    ballx = rnd.Next(10, 15);
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "batubata")
                {

                    if (bola.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;

                        bally = -bally;

                        this.Controls.Remove(x);
                    }
                }
            }


            if (score == 18)
            {
                //tampilkan game berakhir
                gameOver("You WIN");

            }
            if (bola.Top > 1200)
            {
                //game berakhir
                gameOver("You Lose");
            }
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

        }

        private void bola_Click(object sender, EventArgs e)
        {

        }
    }
}
