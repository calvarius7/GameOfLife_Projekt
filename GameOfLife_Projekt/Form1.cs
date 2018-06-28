using Logic;
using System;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife_Projekt
{
    public partial class Form1 : Form
    {
        public CellBuilder Builder { get; private set; }
        public GameMaster GameMaster { get; private set; }

        //Board-Size-Selection would've been nice... 
        public Form1() : this(45) { }

        public Form1(int cubeSize)
        {
            InitComponent();
            InitGame(cubeSize);
        }

        private void InitComponent()
        {
            InitializeComponent();
            StopButton.Enabled = false;
        }

        private void InitGame(int cubeSize)
        {
            GameMaster = new GameMaster(cubeSize)
            {
                Statistics = new Statistics(StatsLabel)
            };
            Builder = new CellBuilder(this.GameMaster);
            Builder.BuildCells(this, InitPanel);

            Controls.Remove(InitPanel);
        }


        //Show Coordinates of cell
        public void GameCell_Hover(object sender, EventArgs e)
        {
            ShowLabel(sender);
        }

        /**
         * Show coordinates of a cell,
         * toogle alive/dead of a cell
         * if a template is selected, this will spawn the template
         */ 
        public void GameCell_Click(object sender, EventArgs e)
        {
            GameCell cell = sender as GameCell;
            GameMaster.SelectCell(cell);

            Builder.SpawnSelection(cell, SpawnSelect);

            ShowLabel(sender);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (GameMaster.Start())
            {
                StartButton.Enabled = false;
                ResetButton.Enabled = false;
                StopButton.Enabled = true;
            }
        }

        private void ShowLabel(object sender)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("X: " + ((GameCell)sender).Col + " Y: " + ((GameCell)sender).Row);
            CoordinatesLabel.Text = sb.ToString();
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            if (GameMaster.Stop())
            {
                StartButton.Enabled = true;
                StopButton.Enabled = false;
                ResetButton.Enabled = true;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            GameMaster.Reset();
        }
    }
}
