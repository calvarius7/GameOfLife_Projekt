using Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_Projekt
{
    abstract class SpawnTemplate
    {
        GameCell start;
        List<GameCell> livingCells;

        public GameCell Start { get => start; set => start = value; }
        public List<GameCell> LivingCells { get => livingCells; set => livingCells = value; }

        public abstract void Spawn();
    }
}
