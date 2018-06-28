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
            int startRow = base.Start.Row;
            int startCol = base.Start.Col;
            List<GameCell> livingCells = new List<GameCell>
            {
                base.Start,
                new GameCell(startRow + 1, startCol),
                new GameCell(startRow + 2, startCol)
            };
            if (new Random().Next(0,2)==0)
            {
                livingCells.Add(new GameCell(startRow, startCol - 1));
                livingCells.Add(new GameCell(startRow + 1, startCol - 2));
            }
            else
            {
                livingCells.Add(new GameCell(startRow, startCol + 1));
                livingCells.Add(new GameCell(startRow + 1, startCol + 2));
            }

            base.LivingCells = livingCells;
        }

        public override void Spawn()
        {
            throw new NotImplementedException();
        }
    }
}
