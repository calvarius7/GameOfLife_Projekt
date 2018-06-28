using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    class GameOfLife
    {
        /**
         * Start one GameOfLife-Generation and set every cell in its correct state
         */
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
                cell.MarkForLife();
            }
        }

        private void BringToLife(GameCell cell)
        {
            int aliveNeighbors = HowManyAliveNeighbors(cell);

            if (aliveNeighbors == 3)
            {
                cell.MarkForLife();
            }
            else
            {
                cell.MarkForDeath();
            }
        }

        private int HowManyAliveNeighbors(GameCell cell)
        {
            return cell.Neighbors.Count(neighbor => neighbor.Alive);
        }
    }
}
