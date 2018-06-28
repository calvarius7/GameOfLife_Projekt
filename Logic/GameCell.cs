using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Logic
{
    public class GameCell : Panel
    {
        private bool alive;
        private bool goingToDie;
        private bool goingToLive;
        private int row;
        private int col;
        
        public List<GameCell> Neighbors { get; set; }
        public bool Alive { get => alive;}
        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }

        public GameCell(int row, int col)
        {
            IsDead();
            this.Row = row;
            this.Col = col;
        }

        public void MarkForDeath()
        {
            goingToDie = true;
            goingToLive = false;
        }

        public void MarkForLife()
        {
            goingToLive = true;
            goingToDie = false;
        }
        public void IsAlive()
        {
            alive = true;
            this.BackColor = Color.LightGray;
        }

        public void IsDead()
        {
            alive = false;
            this.BackColor = Color.Black;
        }

        public void LiveOrDie()
        {
            if (goingToDie)
            {
                IsDead();
            }
            else if(goingToLive)
            {
                IsAlive();
            }
        }
    }
}
