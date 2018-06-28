using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_Projekt
{
    class Glider : SpawnTemplate
    {
        
        public Glider()
        {
            base.Start = new GameCell(12, 12);
            SetNeighbors();
        }

        private void SetNeighbors()
        {
            List<GameCell> livingCells = new List<GameCell>();
            livingCells.Add(base.Start);

            int startRow = base.Start.Row;
            int startCol = base.Start.Col;

            livingCells.Add(new GameCell(startRow, startCol - 1));
            livingCells.Add(new GameCell(startRow + 1, startCol - 2));
            livingCells.Add(new GameCell(startRow + 1, startCol));
            livingCells.Add(new GameCell(startRow + 2, startCol));

            base.LivingCells = livingCells;
        }

        public override void Spawn()
        {
            throw new NotImplementedException();
        }
    }
}
