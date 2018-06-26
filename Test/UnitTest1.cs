using System;
using System.Collections.Generic;
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
        public void GoodNeighborhood()
        {

            Builder builder = new Builder(20, new GameMaster());

            builder.BuildCells(new Form1(), new Panel());
            int cells = 20 * 20;

            Assert.AreEqual(cells, builder.GameMaster.Cells.Count);
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
