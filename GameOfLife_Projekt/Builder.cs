using Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife_Projekt
{
    public class Builder
    {
        private GameMaster gameMaster;
       public GameMaster GameMaster { get => this.gameMaster; set => gameMaster = value; }

        private readonly int cubeSize;

        public Builder(int cubeSize, GameMaster gameMaster)
        {
            this.cubeSize = cubeSize;
            GameMaster = gameMaster;
        }

       public void BuildCells(Form form, Panel start)
        {
            GameCell cell;
            int row = cubeSize;
            while (row > 0)
            {
                int col = cubeSize;
                while (col > 0)
                {
                    cell = new GameCell(row, col)
                    {
                        Size = start.Size,
                        BorderStyle = start.BorderStyle
                    };
                    cell.Location = new Point(start.Location.X + col * cell.Size.Width, start.Location.Y + row * cell.Size.Width);
                    cell.Click += new EventHandler(((Form1)form).gameCell_Click);
                    cell.MouseHover += new EventHandler(((Form1)form).gameCell_Hover);

                    form.Controls.Add(cell);
                    gameMaster.addCells(cell);
                    col--;
                }
                row--;
            }
            GetNeighborhood();
        }

        public void GetNeighborhood()
        {
            foreach(GameCell cell in GameMaster.Cells)
            {
                SetNeighbors(cell);
            }
        }

        private void SetNeighbors(GameCell cell)
        {
            int rowAbove = IndexDown(cell.Row);
            int rowBelow = IndexUp(cell.Row);
            int colRight = IndexUp(cell.Col);
            int colLeft = IndexDown(cell.Col);

            List<GameCell> neighbors = new List<GameCell>();

            neighbors.Add(FindByRowAndCol(rowAbove, colLeft));
            neighbors.Add(FindByRowAndCol(rowAbove, cell.Col));
            neighbors.Add(FindByRowAndCol(rowAbove, colRight));

            neighbors.Add(FindByRowAndCol(cell.Row, colLeft));
            neighbors.Add(FindByRowAndCol(cell.Row, colRight));

            neighbors.Add(FindByRowAndCol(rowBelow, colLeft));
            neighbors.Add(FindByRowAndCol(rowBelow, cell.Col));
            neighbors.Add(FindByRowAndCol(rowBelow, colRight));

            cell.Neighbors = neighbors;
        }

        private GameCell FindByRowAndCol(int row, int col)
        {
            return gameMaster.Cells.Select(cell => cell).First(cell => cell.Row == row && cell.Col == col);
       
        }
            

        private int IndexUp(int start)
        {
            int index = start + 1;
            if (index > cubeSize)
            {
                index = 1;
            }
            return index;
        }

        private int IndexDown(int start)
        {
            int index = start - 1;
            if (index < 1)
            {
                index = cubeSize ;
            }
            return index;
        }
    }
}
