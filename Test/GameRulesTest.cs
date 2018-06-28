using System.Collections.Generic;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class GameRulesTest
    {
        private GameMaster gameMaster;
        private GameCell test;
        private List<GameCell> neighbors;

        private void SetUp()
        {
            gameMaster = new GameMaster(0);
            test = new GameCell(0, 0);
            neighbors = new List<GameCell>();
        }

        [TestMethod]
        public void KillACellUnderPop()
        {
            SetUp();
            test.IsAlive();
            gameMaster.AddCells(test);

            //x < 2 alive neigbors kill a cell
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
            SetUp();
            test.IsAlive();
            gameMaster.AddCells(test);

            //x > 3 alive neigbors kill a cell
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
            SetUp();
            test.IsAlive();
            gameMaster.AddCells(test);

            // 2 - 3 alive neigbors keep cell alive
            GameCell alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);

            test.Neighbors = neighbors;

            gameMaster.GameOfLife();
            Assert.AreEqual(true, test.Alive);
        }
        [TestMethod]
        public void ReviveACell()
        {
            SetUp();
            test.IsDead();
            gameMaster.AddCells(test);
            
            //3 alive neighbors bring a dead cell to live
            GameCell alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);
            alive = new GameCell(0, 0);
            alive.IsAlive();
            neighbors.Add(alive);

            test.Neighbors = neighbors;

            gameMaster.GameOfLife();

            Assert.AreEqual(true, test.Alive);
        }
    }
}
