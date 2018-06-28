using System.Linq;
using GameOfLife_Projekt;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class SpawnTest
    {
        [TestMethod]
        public void SpawnGlider()
        {
            SpawnTemplate template = new Glider(new GameCell(0, 0));

            Assert.AreEqual(5, template.LivingCells.Count);
        }

        [TestMethod]
        public void SpawnPentomino()
        {
            SpawnTemplate template = new Pentomino(new GameCell(0, 0));

            Assert.AreEqual(5, template.LivingCells.Count);
        }
        [TestMethod]
        public void SpawnPulsator()
        {
            SpawnTemplate template = new Pulsator(new GameCell(0, 0));

            Assert.AreEqual(12, template.LivingCells.Count);
        }

        [TestMethod]
        public void SpawnSpaceShip()
        {
            SpawnTemplate template = new SpaceShip(new GameCell(0, 0));

            Assert.AreEqual(11, template.LivingCells.Count);
        }

        [TestMethod]
        public void LeaveRightSide()
        {
            SpawnTemplate template = new Pulsator(new GameCell(15, 45));
            //   O    O
            // SE OOOO OO  S = Start / E = seeYouOnTheOtherSide
            //   O    O
            bool seeYouOnTheOtherSide = template.LivingCells.Select(cell => cell).Any(cell => cell.Row == 15 && cell.Col == 1);

            Assert.IsTrue(seeYouOnTheOtherSide);
        }

        [TestMethod]
        public void LeaveTop()
        {
            SpawnTemplate template = new Pulsator(new GameCell(1, 30));

            //   E    O
            // SO OOOO OO  S = Start / E = seeYouOnTheOtherSide
            //   O    O
            bool seeYouOnTheOtherSide = template.LivingCells.Select(cell => cell).Any(cell => cell.Row == 45 && cell.Col == 32);

            Assert.IsTrue(seeYouOnTheOtherSide);
        }



    }
}
