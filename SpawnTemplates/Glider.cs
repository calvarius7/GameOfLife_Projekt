using Logic;
using System;
using System.Collections.Generic;

namespace GameOfLife_Projekt
{
    public class Glider : SpawnTemplate
    {

        public Glider(GameCell start) : base(start)
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
                new GameCell(ToBigToSmall(startRow + 2), startCol)
            };
            if (new Random().Next(0,2)==0)
            {
                livingCells.Add(new GameCell(startRow, ToBigToSmall(startCol - 1)));
                livingCells.Add(new GameCell(ToBigToSmall(startRow + 1), ToBigToSmall(startCol - 2)));
            }
            else
            {
                livingCells.Add(new GameCell(startRow, ToBigToSmall(startCol + 1)));
                livingCells.Add(new GameCell(ToBigToSmall(startRow + 1), ToBigToSmall(startCol + 2)));
            }

            LivingCells = livingCells;
        }
    }
}
