using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_Projekt
{
    public class Glider : SpawnTemplate
    {

        public Glider() : this(new GameCell(12, 12)) { }
        

        public Glider(GameCell start) : base(start)
        {
            SetNeighbors();
        }

        
        private void SetNeighbors()
        {
            int startRow = base.Start.Row;
            int startCol = base.Start.Col;
            List<GameCell> livingCells = new List<GameCell>
            {
                
                base.Start,
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

            base.LivingCells = livingCells;
        }
    }
}
