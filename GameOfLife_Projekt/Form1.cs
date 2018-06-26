using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife_Projekt
{
    public partial class Form1 : Form
    {

        private GameMaster gameMaster; 
        

        private Builder builder;
        public Builder Builder { get => builder; }

        private int cubeSize;
        public GameMaster GameMaster { get => gameMaster; }

        public Form1()
        {
            InitializeComponent();
            gameMaster = new GameMaster();
            cubeSize = 30;
            builder = new Builder(cubeSize, this.gameMaster);
            InitGame();
        }

        public Form1(int cubeSize)
        {
            InitializeComponent();
            gameMaster = new GameMaster();
            builder = new Builder(cubeSize, this.gameMaster);
            InitGame();
        }

        private void InitGame()
        {
            builder.BuildCells(this, panel1);

            this.Controls.Remove(panel1);
        }

        private void start_Click(object sender, EventArgs e)
        {
            int count = 0;
            while (count < 100)
            {
                Task.Run(() => gameMaster.GameOfLife()).Wait(500);
                label1.Text = "Generation: " + count.ToString();
                this.Refresh();
                
                count++;
            }
                                 
        }
        
        public void gameCell_Hover(object sender, EventArgs e)
        {
            ShowLabel(sender);
        }

        public void gameCell_Click(object sender, EventArgs e)
        {
            if (!((GameCell)sender).Alive) { 
            ((GameCell)sender).IsAlive();
            }
            else
            {
                ((GameCell)sender).IsDead();

            }
            ShowLabel(sender);
        }

        private void ShowLabel(object sender)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("X: " + ((GameCell)sender).Col + " Y: " + ((GameCell)sender).Row);
            label1.Text = sb.ToString();
        }
    }
}
