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
        private readonly Label drawStatsHere;

        public int Generation { get => generation; set => generation = value > 0 ? value : 0; }
        public int CurrentlyLiving { get => currentlyLiving; set => currentlyLiving = value > 0 ? value : 0; }

        public Statistics(Label drawStatsHere)
        {
            this.drawStatsHere = drawStatsHere;
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
            drawStatsHere.Text = "Generation:\n" + generation;
            drawStatsHere.Text += "\nLiving cells:\n" + currentlyLiving;
            drawStatsHere.Text += "\nMax. cells:\n" + maximumCells;
            drawStatsHere.Text += "\nMin. cells:\n" + minimumCells;
            drawStatsHere.Text += "\nAvg. living cells / gen.:\n" + GetAverageCells(generation);
            drawStatsHere.Text += "\nTotal cells:\n" + totalCells;
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
            currentlyLiving = 0;
            ShowStats();
        }

    }
}
