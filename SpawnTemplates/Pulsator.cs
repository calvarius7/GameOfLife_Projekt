using Logic;
using System.Collections.Generic;

namespace GameOfLife_Projekt
{
    public class Pulsator : SpawnTemplate
    {
        
        public Pulsator(GameCell start) : base(start)
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
                new GameCell(startRow, ToBigToSmall(startCol+1)),
                new GameCell(ToBigToSmall(startRow +1), ToBigToSmall(startCol+2)),
                new GameCell(ToBigToSmall(startRow -1), ToBigToSmall(startCol+2)),
                new GameCell(startRow, ToBigToSmall(startCol+3)),
                new GameCell(startRow, ToBigToSmall(startCol+4)),
                new GameCell(startRow, ToBigToSmall(startCol+5)),
                new GameCell(startRow, ToBigToSmall(startCol+6)),
                new GameCell(ToBigToSmall(startRow+1), ToBigToSmall(startCol+7)),
                new GameCell(ToBigToSmall(startRow-1), ToBigToSmall(startCol+7)),
                new GameCell(startRow, ToBigToSmall(startCol+8)),
                new GameCell(startRow, ToBigToSmall(startCol+9))
            };

            LivingCells = livingCells;
        }
    }
}
