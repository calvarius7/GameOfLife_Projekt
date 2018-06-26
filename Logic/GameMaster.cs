using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GameMaster
    {
        private readonly List<GameCell> cells;
        public List<GameCell> Cells { get => this.cells; }

        public GameMaster()
        {
            cells = new List<GameCell>();
        }
        
        public void addCells(GameCell cell)
        {
            cells.Add(cell);
        }

        public void GameOfLife()
        {
            Judge();
            foreach(GameCell cell in cells)
            {
                cell.LiveOrDie();
            }
        }

        public void Judge()
        {
            foreach (GameCell cell in cells)
            {
                if (cell.Alive)
                {
                    Executioner(cell);
                }
                else
                {
                    BringToLife(cell);
                }
            }
        }

        private void Executioner(GameCell cell) {
            int aliveNeighbors = HowManyAliveNeighbors(cell);

            if(aliveNeighbors > 3 || aliveNeighbors < 2)
            {
                cell.MarkForDeath();
            }
            else
            {
                cell.MarkForRevive();
            }
        }

        private void BringToLife(GameCell cell)
        {
            int aliveNeighbors = HowManyAliveNeighbors(cell);
            if(aliveNeighbors == 3)
            {
                cell.MarkForRevive();
            }
            else
            {
                cell.MarkForDeath();
            }
         }

        private int HowManyAliveNeighbors(GameCell cell)
        {
            int alive = 0;

            foreach (GameCell neighbour in cell.Neighbors)
            {
                if (neighbour.Alive)
                {
                    alive++;
                }
            }
            return alive;
        }

    }
}
