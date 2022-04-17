﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Game_1
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            PipeBottom.Left -= pipeSpeed;
            PipeTop.Left -= pipeSpeed;
            ScoreText.Text = "Score: " + score;

            if (PipeBottom.Left < -150)
            {
                PipeBottom.Left = 800;
                score++;
            }
            if (PipeTop.Left < -180)
            {
                PipeTop.Left = 950;
                score++;
            }
            if (FlappyBird.Bounds.IntersectsWith(PipeBottom.Bounds) ||
                    FlappyBird.Bounds.IntersectsWith(PipeTop.Bounds) ||
                    FlappyBird.Bounds.IntersectsWith(Ground.Bounds)
                    )
            {
                endgame();
            }
            if (score > 5)
            {
                pipeSpeed = 15;
            }
            if (FlappyBird.Top < -25)
            {
                endgame();
            }


        }

        private void GameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }

        }

        private void GameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endgame()
        {
            GameTimer.Stop();
            ScoreText.Text += " Game Over!!!";
        }
    }
}
