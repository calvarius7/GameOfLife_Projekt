using System;
using System.Windows.Forms;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class StatsTest
    {
        private Label label;
        private Statistics stats;

        private void SetUp()
        {
            label = new Label();
            stats = new Statistics(label);
        }

        [TestMethod]
        public void DrawStats()
        {
            SetUp();

            String expected = "Generation:\n" + 0
                + "\nLiving cells:\n" + 0
                + "\nMax. cells:\n" + 0
                + "\nMin. cells:\n" + 0
                + "\nAvg. living cells / gen.:\n" + 0
                + "\nTotal cells:\n" + 0;

            stats.ShowStats();

            Assert.AreEqual(expected, label.Text);
        }

        [TestMethod]
        public void FillStats()
        {
            SetUp();

            stats.Generation = 1;
            stats.CurrentlyLiving = 10;

            String expected = "Generation:\n" + 1
                + "\nLiving cells:\n" + 10
                + "\nMax. cells:\n" + 10
                + "\nMin. cells:\n" + 10
                + "\nAvg. living cells / gen.:\n" + 10
                + "\nTotal cells:\n" + 10;

            stats.ShowStats();

            Assert.AreEqual(expected, label.Text);
        }


        [TestMethod]
        public void CalcStats()
        {
            SetUp();

            stats.Generation += 1;
            stats.CurrentlyLiving = 15;
            stats.ShowStats();

            stats.Generation += 1;
            stats.CurrentlyLiving = 10;
            stats.ShowStats();

            String expected = "Generation:\n" + 2
              + "\nLiving cells:\n" + 10
              + "\nMax. cells:\n" + 15
              + "\nMin. cells:\n" + 10
              + "\nAvg. living cells / gen.:\n" + 12
              + "\nTotal cells:\n" + 25;

            Assert.AreEqual(expected, label.Text);
        }

        [TestMethod]
        public void NegativStats()
        {
            SetUp();

            stats.Generation = -1;
            stats.CurrentlyLiving = -15;
            stats.ShowStats();

            String expected = "Generation:\n" + 0
             + "\nLiving cells:\n" + 0
             + "\nMax. cells:\n" + 0
             + "\nMin. cells:\n" + 0
             + "\nAvg. living cells / gen.:\n" + 0
             + "\nTotal cells:\n" + 0;

            Assert.AreEqual(expected, label.Text);
        }
    }
}
