using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_Projekt
{
    public class SpaceShip : SpawnTemplate
    {
        public SpaceShip()
        {
            Start = new GameCell(10, 30);
            SetNeighbors();

        }

        private void SetNeighbors()
        {
            int startRow = Start.Row;
            int startCol = Start.Col;
            List<GameCell> livingCells = new List<GameCell>
            {
                Start,
                new GameCell(startRow - 1, startCol),
                new GameCell(startRow - 2, startCol)
            };

            livingCells.Add(new GameCell(startRow - 3, startCol + 1));
            livingCells.Add(new GameCell(startRow - 4, startCol + 3));
            livingCells.Add(new GameCell(startRow - 3, startCol + 5));
            livingCells.Add(new GameCell(startRow - 1, startCol + 5));
            livingCells.Add(new GameCell(startRow, startCol + 4));
            livingCells.Add(new GameCell(startRow, startCol + 3));
            livingCells.Add(new GameCell(startRow, startCol + 2));
            livingCells.Add(new GameCell(startRow, startCol + 1));


            LivingCells = livingCells;
        }
    }
}
