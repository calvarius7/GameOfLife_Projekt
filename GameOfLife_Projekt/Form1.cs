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
        private BackgroundWorker backgroundWorker1;
        private GameMaster gameMaster;
        private Builder builder;
        public Builder Builder { get => builder; }
        public GameMaster GameMaster { get => gameMaster; }

        public Form1() : this(45) { }


        public Form1(int cubeSize)
        {
            InitComponent();
            InitGame(cubeSize);
            InitBackGroundWorker();
        }

        private void InitComponent()
        {
            InitializeComponent();
            stop.Enabled = false;

        }

        private void InitBackGroundWorker()
        {
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void InitGame(int cubeSize)
        {
            gameMaster = new GameMaster();
            builder = new Builder(cubeSize, this.gameMaster);
            builder.BuildCells(this, panel1);

            this.Controls.Remove(panel1);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
            {
                gameMaster.GameOfLife();
                System.Threading.Thread.Sleep(200);
            }
            e.Cancel = true;
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                start.Enabled = false;
                Reset.Enabled = false;
                stop.Enabled = true;
                backgroundWorker1.RunWorkerAsync();
                
            }

        }

        public void gameCell_Hover(object sender, EventArgs e)
        {
            ShowLabel(sender);
        }

        public void gameCell_Click(object sender, EventArgs e)
        {
            GameCell cell = sender as GameCell;
            if (!cell.Alive)
            {
                cell.IsAlive();
            }
            else
            {
                cell.IsDead();

            }
            ShowLabel(sender);
        }

        private void ShowLabel(object sender)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("X: " + ((GameCell)sender).Col + " Y: " + ((GameCell)sender).Row);
            label1.Text = sb.ToString();
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                start.Enabled = true;
                stop.Enabled = false;
                Reset.Enabled = true;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
               foreach(GameCell cell in GameMaster.Cells)
                {
                    cell.IsDead();
                }
            }
        }
    }
}
