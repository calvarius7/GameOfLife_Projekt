﻿using Logic;
using System;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife_Projekt
{
    public partial class Form1 : Form
    {
        private GameMaster gameMaster;
        private CellBuilder builder;
        public CellBuilder Builder { get => builder; }
        public GameMaster GameMaster { get => gameMaster; }

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
            gameMaster = new GameMaster(cubeSize)
            {
                Statistics = new Statistics(StatsLabel)
            };
            builder = new CellBuilder(this.gameMaster);
            builder.BuildCells(this, InitPanel);

            Controls.Remove(InitPanel);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (gameMaster.Start())
            {
                StartButton.Enabled = false;
                ResetButton.Enabled = false;
                StopButton.Enabled = true;
            }
        }

       public void GameCell_Hover(object sender, EventArgs e)
        {
            ShowLabel(sender);
        }

       public void GameCell_Click(object sender, EventArgs e)
        {
            GameCell cell = sender as GameCell;
            gameMaster.SelecetCell(cell);
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
            if (gameMaster.Stop())
            {
                StartButton.Enabled = true;
                StopButton.Enabled = false;
                ResetButton.Enabled = true;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            gameMaster.Reset();
        }

        private void Spawn_Click(object sender, EventArgs e)
        {
            if (SpawnSelect.SelectedItem != null)
            {
                SpawnTemplate spawn;

                switch (SpawnSelect.SelectedItem.ToString())
                {
                    case "Glider":
                        spawn = new Glider();
                        break;
                    case "Pentomino":
                        spawn = new Pentomino();
                        break;
                    case "SpaceShip":
                        spawn = new SpaceShip();
                        break;
                    case "Pulsator":
                        spawn = new Pulsator();
                        break;
                    default:
                        spawn = null;
                        break;
                }
                if (spawn != null)
                {
                    foreach (GameCell cell in spawn.LivingCells)
                    {
                        GameCell found = gameMaster.FindByRowAndCol(cell.Row, cell.Col);
                        found.IsAlive();
                    }
                }
            }
            
        }
    }
}
