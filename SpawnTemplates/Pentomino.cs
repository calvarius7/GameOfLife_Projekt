using Logic;
using System;
using System.Collections.Generic;

namespace GameOfLife_Projekt
{
    public class Pentomino : SpawnTemplate
    {
        public Pentomino(GameCell start) : base(start)
        {
            SetNeighbors();
        }

        protected override void SetNeighbors()
        {
            int startRow = Start.Row;
            int startCol = Start.Col;
            List<GameCell> livingCells = new List<GameCell>
            {
                Start,
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

            LivingCells = livingCells;
        }
    }
}
