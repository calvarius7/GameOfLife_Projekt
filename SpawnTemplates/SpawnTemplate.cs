using Logic;
using System.Collections.Generic;

namespace GameOfLife_Projekt
{   
    public abstract class SpawnTemplate
    {
        public GameCell Start { get; set; }
        public List<GameCell> LivingCells { get; set; }
        public int CubeSize { get; set; } = 45;

        protected SpawnTemplate(GameCell start)
        {
            Start = new GameCell(ToBigToSmall(start.Row), ToBigToSmall(start.Col));
        }

        abstract protected void SetNeighbors();
        
        /**
         * Handle if row / col would leave cube
         * => infinit cube
         */ 
        protected int ToBigToSmall(int index)
        {
            if(index < 1)
            {
                index = CubeSize + index;
            }
            if(index > CubeSize)
            {
               index = index- CubeSize;
            }
            return index;

        }
    }
}
