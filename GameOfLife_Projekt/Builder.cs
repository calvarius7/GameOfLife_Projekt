using Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLife_Projekt
{
    public class CellBuilder
    {
        public GameMaster GameMaster { get; set; }

        public CellBuilder(GameMaster gameMaster)
        {
            GameMaster = gameMaster;
        }

        public void BuildCells(Form form, Panel start)
        {
            int row = GameMaster.CubeSize;
            while (row > 0)
            {
                int col = GameMaster.CubeSize;
                while (col > 0)
                {
                    CreateOneCell(form, start, row, col);
                    col--;
                }
                row--;
            }
            GameMaster.GetNeighborhood();
        }

        public void SpawnSelection(GameCell start, ComboBox selected)
        {
            if (selected.SelectedItem != null)
            {
                SpawnTemplate spawn;

                switch (selected.SelectedItem.ToString())
                {
                    case "Glider":
                        spawn = new Glider(start);
                        break;
                    case "Pentomino":
                        spawn = new Pentomino(start);
                        break;
                    case "SpaceShip":
                        spawn = new SpaceShip(start);
                        break;
                    case "Pulsator":
                        spawn = new Pulsator(start);
                        break;
                    default:
                        spawn = null;
                        break;
                }

                SpawnSelected(spawn);
            }
        }

        private void CreateOneCell(Form form, Panel start, int row, int col)
        {
            GameCell cell = new GameCell(row, col)
            {
                Size = start.Size,
                BorderStyle = start.BorderStyle
            };
            cell.Location = new Point(start.Location.X + col * cell.Size.Width, start.Location.Y + row * cell.Size.Width);
            cell.Click += new EventHandler(((Form1)form).GameCell_Click);
            cell.MouseHover += new EventHandler(((Form1)form).GameCell_Hover);

            form.Controls.Add(cell);
            GameMaster.AddCells(cell);

        }

        private void SpawnSelected(SpawnTemplate spawn)
        {
            if (spawn != null)
            {
                foreach (GameCell spawnCell in spawn.LivingCells)
                {
                    GameCell found = GameMaster.FindByRowAndCol(spawnCell.Row, spawnCell.Col);
                    found.IsAlive();
                }
            }
        }
    }
}
