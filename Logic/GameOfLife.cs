using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class GameOfLife
    {
        public void Play(List<GameCell> populaiton)
        {
            Judge(populaiton);
            foreach (GameCell cell in populaiton)
            {
                cell.LiveOrDie();
            }
        }

        private void Judge(List<GameCell> populaiton)
        {
            foreach (GameCell cell in populaiton)
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

        private void Executioner(GameCell cell)
        {
            int aliveNeighbors = HowManyAliveNeighbors(cell);

            if (aliveNeighbors > 3 || aliveNeighbors < 2)
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
            if (aliveNeighbors == 3)
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
