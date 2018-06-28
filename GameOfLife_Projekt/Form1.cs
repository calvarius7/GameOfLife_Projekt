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
        private Statistics statistics;
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
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);

        }

        private void InitGame(int cubeSize)
        {
            gameMaster = new GameMaster();
            statistics = new Statistics(StatsLabel);
            builder = new Builder(cubeSize, this.gameMaster);
            builder.BuildCells(this, panel1);

            this.Controls.Remove(panel1);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int runs = 0;
            while (!worker.CancellationPending)
            {
                gameMaster.GameOfLife();
                System.Threading.Thread.Sleep(200);
                worker.ReportProgress(++runs);
            }
            e.Cancel = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statistics.Generation = e.ProgressPercentage;
            statistics.CurrentlyLiving = gameMaster.Cells.Count(cell => cell.Alive);
            statistics.ShowStats();
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
            if (!backgroundWorker1.IsBusy)
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
            }
            ShowLabel(sender);
        }

        private void ShowLabel(object sender)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("X: " + ((GameCell)sender).Col + " Y: " + ((GameCell)sender).Row);
            CoordinatesLabel.Text = sb.ToString();
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
                statistics.SetZero();
            }
        }
    }
}
