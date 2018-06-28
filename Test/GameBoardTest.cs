using System.Linq;
using System.Windows.Forms;
using GameOfLife_Projekt;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class GameBoardTest
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
    }
}
