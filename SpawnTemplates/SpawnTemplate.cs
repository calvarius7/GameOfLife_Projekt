using Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_Projekt
{
    public abstract class SpawnTemplate
    {
        GameCell start;
        List<GameCell> livingCells;
        int cubeSize = 45;

        public GameCell Start { get => start; set => start = value; }
        public List<GameCell> LivingCells { get => livingCells; set => livingCells = value; }
        public int CubeSize { get => cubeSize; set => cubeSize = value; }

        protected SpawnTemplate(GameCell start)
        {
            Start = new GameCell(ToBigToSmall(start.Row), ToBigToSmall(start.Col));
        }

        abstract protected void SetNeighbors();

        protected int ToBigToSmall(int index)
        {
            if(index < 1)
            {
                index = cubeSize + index;
            }
            if(index > cubeSize)
            {
               index = index- cubeSize;
            }
            return index;

        }
    }
}
