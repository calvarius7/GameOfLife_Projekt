using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic
{
    public class Statistics
    {
        private int currentlyLiving = 0;
        private int maximumCells = 0;
        private int minimumCells = 0;
        private int totalCells = 0;
        private int generation = 0;
        private readonly Label drawStats;

        public int Generation { get => generation; set => generation = value; }
        public int CurrentlyLiving { get => currentlyLiving; set => currentlyLiving = value; }

        public Statistics(Label drawStatsHere)
        {
            this.drawStats = drawStatsHere;
            DrawStats();
        }

        public void ShowStats()
        {
            GetMinMaxCells();
            totalCells += currentlyLiving;
            DrawStats();
        }

        private void DrawStats()
        {
            drawStats.Text = "Generation:\n" + generation;
            drawStats.Text += "\nLiving cells:\n" + currentlyLiving;
            drawStats.Text += "\nMax. cells:\n" + maximumCells;
            drawStats.Text += "\nMin. cells:\n" + minimumCells;
            drawStats.Text += "\nAvg. living cells / gen.:\n" + GetAverageCells(generation);
            drawStats.Text += "\nTotal cells:\n" + totalCells;
        }

        private int GetAverageCells(int generations)
        {
            return totalCells / (generations > 0 ? generations : 1);
        }

        private void GetMinMaxCells()
        {
            if (currentlyLiving > maximumCells)
            {
                maximumCells = currentlyLiving;
            }
            if (currentlyLiving < minimumCells || minimumCells == 0)
            {
                minimumCells = currentlyLiving;
            }
        }

        public void SetZero()
        {
            minimumCells = 0;
            maximumCells = 0;
            generation = 0;
            totalCells = 0;
            ShowStats();
        }

    }
}
