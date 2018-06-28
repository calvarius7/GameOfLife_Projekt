using Logic;
using System.Collections.Generic;

namespace GameOfLife_Projekt
{
    public class SpaceShip : SpawnTemplate
    {
        public SpaceShip(GameCell start) : base(start)
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
                new GameCell(ToBigToSmall(startRow - 1), startCol),
                new GameCell(ToBigToSmall(startRow - 2), startCol)
            };

            livingCells.Add(new GameCell(ToBigToSmall(startRow - 3), ToBigToSmall(startCol + 1)));
            livingCells.Add(new GameCell(ToBigToSmall(startRow - 4), ToBigToSmall(startCol + 3)));
            livingCells.Add(new GameCell(ToBigToSmall(startRow - 3), ToBigToSmall(startCol + 5)));
            livingCells.Add(new GameCell(ToBigToSmall(startRow - 1), ToBigToSmall(startCol + 5)));
            livingCells.Add(new GameCell(startRow, ToBigToSmall(startCol + 4)));
            livingCells.Add(new GameCell(startRow, ToBigToSmall(startCol + 3)));
            livingCells.Add(new GameCell(startRow, ToBigToSmall(startCol + 2)));
            livingCells.Add(new GameCell(startRow, ToBigToSmall(startCol + 1)));

            LivingCells = livingCells;
        }
    }
}
