using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameOfLife_Projekt;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BuildACube()
        {
            
            CellBuilder builder = new CellBuilder(new GameMaster(10));

            builder.BuildCells(new Form1(), new Panel());
            int cells = 10 * 10;

            Assert.AreEqual(cells, builder.GameMaster.Cells.Count);
        }

        [TestMethod]
        public void BuildEmptyCube()
        {
            CellBuilder builder = new CellBuilder(new GameMaster(0));

            builder.BuildCells(new Form1(), new Panel());
            int cells = 0;

            Assert.AreEqual(cells, builder.GameMaster.Cells.Count);
        }
        [TestMethod]
        public void CoordinatesCheck()
        {
            Form1 form1 = new Form1();
            int row = 1;
            int col = 1;
         
            Assert.IsTrue(form1.GameMaster.Cells.Any(cell => cell.Row == row && cell.Col == col));
        }

        [TestMethod]
        public void NeighborhoodSize()
        {
            Form1 form1 = new Form1();
            int neighborsExpected = 8;
            int actualNeigbors = form1.GameMaster.Cells[0].Neighbors.Count;
            Assert.AreEqual(neighborsExpected, actualNeigbors );
        }

        [TestMethod]
        public void GoodNeighborhood()
        {
            Form1 form1 = new Form1(20);
            int row = 12;
            int col = 12;
            GameCell gameCell = form1.GameMaster.Cells.Select(cell => cell).First(cell => cell.Row == row && cell.Col == col);
      
            bool topLeft = gameCell.Neighbors.Any(neighbor => neighbor.Row == 11 && neighbor.Col == 11);
            bool topRight = gameCell.Neighbors.Any(neighbor => neighbor.Row == 11 && neighbor.Col == 13);
            bool bottomRight = gameCell.Neighbors.Any(neighbor => neighbor.Row == 13 && neighbor.Col == 13);
            bool bottomLeft = gameCell.Neighbors.Any(neighbor => neighbor.Row == 13 && neighbor.Col == 11);
           
            Assert.IsTrue(topLeft);
            Assert.IsTrue(topRight);
            Assert.IsTrue(bottomLeft);
            Assert.IsTrue(bottomRight);

        }
        [TestMethod]
        public void BorderNeighborhood()
        {
            Form1 form1 = new Form1(20);
            int row = 12;
            int col = 1;
            GameCell gameCell = form1.GameMaster.Cells.Select(cell => cell).First(cell => cell.Row == row && cell.Col == col);
                  
            bool topLeft = gameCell.Neighbors.Any(neighbor => neighbor.Row == 11 && neighbor.Col == 20);
            bool topRight = gameCell.Neighbors.Any(neighbor => neighbor.Row == 11 && neighbor.Col == 2);
            bool bottomRight = gameCell.Neighbors.Any(neighbor => neighbor.Row == 13 && neighbor.Col == 2);
            bool bottomLeft = gameCell.Neighbors.Any(neighbor => neighbor.Row == 13 && neighbor.Col == 20);

            Assert.IsTrue(topLeft);
            Assert.IsTrue(topRight);
            Assert.IsTrue(bottomLeft);
            Assert.IsTrue(bottomRight);

        }

        [TestMethod]
        public void KillACellUnderPop()
        {
            GameMaster gameMaster = new GameMaster(0);
            GameCell test = new GameCell(0, 0);
            test.IsAlive();
            gameMaster.AddCells(test);

            //x < 2 alive neigbors kill a cell
            List<GameCell> neighbors = new List<GameCell>();
            neighbors.Add(new GameCell(0, 0));
            neighbors.Add(new GameCell(0, 0));
            neighbors.Add(new GameCell(0, 0));
            neighbors.Add(new GameCell(0, 0));

            test.Neighbors = neighbors;
            gameMaster.AddCells(test);

            gameMaster.GameOfLife();

            Assert.AreEqual(false, test.Alive);
        }
        [TestMethod]
        public void KillACellOverpop()
        {
            GameMaster gameMaster = new GameMaster(0);
            GameCell test = new GameCell(0, 0);
            test.IsAlive();
            gameMaster.AddCells(test);

            //x > 3 alive neigbors kill a cell
            List<GameCell> neighbors = new List<GameCell>();
            GameCell alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);

            test.Neighbors = neighbors;
            gameMaster.AddCells(test);

            gameMaster.GameOfLife();

            Assert.AreEqual(false, test.Alive);
        }

        [TestMethod]
        public void KeepAlive()
        {
            GameMaster gameMaster = new GameMaster(0);
            GameCell test = new GameCell(0, 0);
            test.IsAlive();
            gameMaster.AddCells(test);

            // 2 - 3 alive neigbors keep cell alive
            List<GameCell> neighbors = new List<GameCell>();
            GameCell alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            neighbors.Add(new GameCell(0, 0));
            neighbors.Add(new GameCell(0, 0));

            test.Neighbors = neighbors;

            gameMaster.GameOfLife();
            Assert.AreEqual(true, test.Alive);
        }
        [TestMethod]
        public void ReviveACell()
        {
            GameMaster gameMaster = new GameMaster(0);
            GameCell test = new GameCell(0, 0);
            test.IsDead();
            gameMaster.AddCells(test);

            //3 alive neighbors bring a dead cell to live
            List<GameCell> neighbors = new List<GameCell>();
            GameCell alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            neighbors.Add(new GameCell(0, 0));
            neighbors.Add(new GameCell(0, 0));

            test.Neighbors = neighbors;

            gameMaster.GameOfLife();

            Assert.AreEqual(true, test.Alive);
        }


        [TestMethod]
        public void DrawStats()
        {
            Label label = new Label();
            Statistics stats = new Statistics(label);

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
            Label label = new Label();
            Statistics stats = new Statistics(label);

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
            Label label = new Label();
            Statistics stats = new Statistics(label);

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
              + "\nTotal cells:\n" +25;

            Assert.AreEqual(expected, label.Text);
        }

        [TestMethod]
        public void NegativStats()
        {
            Label label = new Label();
            Statistics stats = new Statistics(label);

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
