using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_Projekt
{
    public class Pentomino : SpawnTemplate
    {
        public Pentomino(GameCell start) : base(start)
        {
            SetNeighbors();
        }

        public Pentomino() : this(new GameCell(25, 25)) { }

        private void SetNeighbors()
        {
            int startRow = base.Start.Row;
            int startCol = base.Start.Col;
            List<GameCell> livingCells = new List<GameCell>
            {
                base.Start,
                new GameCell(ToBigToSmall(startRow + 1), startCol),
                new GameCell(ToBigToSmall(startRow - 1), startCol)
            };
            if (new Random().Next(0, 2) == 0)
            {
                livingCells.Add(new GameCell(startRow, ToBigToSmall(startCol - 1)));
                livingCells.Add(new GameCell(ToBigToSmall(startRow - 1), ToBigToSmall(startCol + 1)));
            }
            else
            {
                livingCells.Add(new GameCell(startRow, ToBigToSmall(startCol + 1)));
                livingCells.Add(new GameCell(ToBigToSmall(startRow - 1), ToBigToSmall(startCol - 1)));
            }

            base.LivingCells = livingCells;
        }
    }
}
