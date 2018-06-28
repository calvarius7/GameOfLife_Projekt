﻿using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_Projekt
{
    public class Pulsator : SpawnTemplate
    {
        
        public Pulsator(GameCell start) : base(start)
        {
            SetNeighbors();
        }

        public Pulsator() : this(new GameCell(36, 12)) { }

        private void SetNeighbors()
        {
            int startRow = base.Start.Row;
            int startCol = base.Start.Col;
            List<GameCell> livingCells = new List<GameCell>
            {
                base.Start,
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

            base.LivingCells = livingCells;
        }
    }
}
