using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpPong
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Bitmap bmp;
        Random rnd;
        Ball ball;
        Paddle paddle1;
        Paddle paddle2;

        int player1 = 0;
        int player2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            timer1.Enabled = true;
            rnd = new Random();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bmp);

            //add game objects
            ball = new Ball(ClientSize.Width / 2, ClientSize.Height / 2, 50, ranDirection(), ranDirection(), Color.Purple);
            paddle1 = new Paddle(0, 0, 75, 50, 50, Color.DarkOrange);
            paddle2 = new Paddle(pictureBox1.Width - 50, 0, 75, 50, 50, Color.DarkBlue);
        }
        public int ranDirection()
        {
            int r = rnd.Next(1, 100);
            if(r > 50)
            {
                return -10;
            }
            return 10;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            gfx.DrawString($"p1: {player1} || p2: {player2}", new Font("TimeNewRoman", 12), new SolidBrush(Color.Red), new Point(ClientSize.Width/2-25, 5));

            ball.erase(gfx, BackColor);
            ball.move(ClientSize.Width, ClientSize.Height);
            ball.draw(gfx);

            if (ball.hitbox.IntersectsWith(paddle1.hitbox))
            {
                ball.reverseX();
                ball.xspeed += 5;
                player1 += 1;
            }
            if (ball.hitbox.IntersectsWith(paddle2.hitbox)){
                ball.reverseX();
                ball.xspeed += -5;
                player2 += 1;
            }
            if(ball.X < 0)
            {
                endGame();
                MessageBox.Show($"Player 2 Wins with a score of {player2}!");
                
            }
            if(ball.X + ball.Size > pictureBox1.Width)
            {
                endGame();
                MessageBox.Show($"Player 1 Win swith a score of {player1}!");
                
            }

            paddle1.erase(gfx, BackColor);
            paddle1.draw(gfx);

            paddle2.erase(gfx, BackColor);
            paddle2.draw(gfx);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W && paddle1.y > 0)
            {

                paddle1.erase(gfx, BackColor);
                paddle1.y -= paddle1.Yspeed;
                paddle1.hitbox = new Rectangle(paddle1.x, paddle1.y, paddle1.Width, paddle1.Height);
            }
            if(e.KeyCode == Keys.S && paddle1.y + paddle1.Height < pictureBox1.Height)
            {
                paddle1.erase(gfx, BackColor);
                paddle1.y += paddle1.Yspeed;
                paddle1.hitbox = new Rectangle(paddle1.x, paddle1.y, paddle1.Width, paddle1.Height);

            }
            if(e.KeyCode == Keys.Up && paddle2.y > 0)
            {
                paddle2.erase(gfx, BackColor);
                paddle2.y -= paddle2.Yspeed;
                paddle2.hitbox = new Rectangle(paddle2.x, paddle2.y, paddle2.Width, paddle2.Height);
            }
            if (e.KeyCode == Keys.Down && paddle2.y + paddle2.Height < pictureBox1.Height)
            {
                paddle2.erase(gfx, BackColor);
                paddle2.y += paddle2.Yspeed;
                paddle2.hitbox = new Rectangle(paddle2.x, paddle2.y, paddle2.Width, paddle2.Height);
            }
        }
        public void endGame()
        {
            timer1.Stop();
            gfx.Clear(BackColor);
        }
    }
}
