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
            
            Builder builder = new Builder(20, new GameMaster());

            builder.BuildCells(new Form1(), new Panel());
            int cells = 20 * 20;

            Assert.AreEqual(cells, builder.GameMaster.Cells.Count);
        }

        [TestMethod]
        public void BuildEmptyCube()
        {
            Builder builder = new Builder(0, new GameMaster());

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
            bool topLeft = false;
            bool topRight = false;
            bool bottomRight = false;
            bool bottomLeft = false;
           
            topLeft = gameCell.Neighbors.Any(neighbor => neighbor.Row == 11 && neighbor.Col == 11);
            topRight = gameCell.Neighbors.Any(neighbor => neighbor.Row == 11 && neighbor.Col == 13);
            bottomRight = gameCell.Neighbors.Any(neighbor => neighbor.Row == 13 && neighbor.Col == 13);
            bottomLeft = gameCell.Neighbors.Any(neighbor => neighbor.Row == 13 && neighbor.Col == 11);
           
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
            bool topLeft = false;
            bool topRight = false;
            bool bottomRight = false;
            bool bottomLeft = false;
            
            
            topLeft = gameCell.Neighbors.Any(neighbor => neighbor.Row == 11 && neighbor.Col == 20);
            topRight = gameCell.Neighbors.Any(neighbor => neighbor.Row == 11 && neighbor.Col == 2);
            bottomRight = gameCell.Neighbors.Any(neighbor => neighbor.Row == 13 && neighbor.Col == 2);
            bottomLeft = gameCell.Neighbors.Any(neighbor => neighbor.Row == 13 && neighbor.Col == 20);

            Assert.IsTrue(topLeft);
            Assert.IsTrue(topRight);
            Assert.IsTrue(bottomLeft);
            Assert.IsTrue(bottomRight);

        }

        [TestMethod]
        public void KillACellUnderPop()
        {
            GameMaster gameMaster = new GameMaster();
            GameCell test = new GameCell(0, 0);
            test.IsAlive();
            gameMaster.addCells(test);

            //< 2 alive neigbors kill a cell
            List<GameCell> neighbors = new List<GameCell>();
            neighbors.Add(new GameCell(0, 0));
            neighbors.Add(new GameCell(0, 0));
            neighbors.Add(new GameCell(0, 0));
            neighbors.Add(new GameCell(0, 0));

            test.Neighbors = neighbors;
            gameMaster.addCells(test);

            gameMaster.GameOfLife();

            Assert.AreEqual(false, test.Alive);
        }
        [TestMethod]
        public void KillACellOverpop()
        {
            GameMaster gameMaster = new GameMaster();
            GameCell test = new GameCell(0, 0);
            test.IsAlive();
            gameMaster.addCells(test);

            //> 3 alive neigbors kill a cell
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
            gameMaster.addCells(test);

            gameMaster.GameOfLife();

            Assert.AreEqual(false, test.Alive);
        }

        [TestMethod]
        public void KeepAlive()
        {
            GameMaster gameMaster = new GameMaster();
            GameCell test = new GameCell(0, 0);
            test.IsAlive();
            gameMaster.addCells(test);

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
            GameMaster gameMaster = new GameMaster();
            GameCell test = new GameCell(0, 0);
            test.IsDead();
            gameMaster.addCells(test);

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

    }
}
