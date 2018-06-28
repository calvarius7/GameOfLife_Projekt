using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GameMaster
    {
        private readonly int cubeSize;
        private readonly List<GameCell> cells;
        public List<GameCell> Cells { get => this.cells; }

        public int CubeSize => cubeSize;

        public GameMaster(int cubeSize)
        {
            this.cubeSize = cubeSize;
            cells = new List<GameCell>();
        }
        
        public void addCells(GameCell cell)
        {
            cells.Add(cell);
        }

        public void GameOfLife()
        {
            GameOfLife game = new GameOfLife();
            game.Play(cells);
            
        }
        
        public void GetNeighborhood()
        {
            foreach (GameCell cell in Cells)
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
            return cells.Select(cell => cell).First(cell => cell.Row == row && cell.Col == col);
        }


        private int IndexUp(int start)
        {
            int index = start + 1;
            if (index > CubeSize)
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
                index = CubeSize;
            }
            return index;
        }

    }
}
