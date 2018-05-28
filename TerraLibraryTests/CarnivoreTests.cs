using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;

namespace TerraLibraryTests
{
    [TestClass]
    public class CarnivoreTests
    {
        private Terrarium BeginTerrarium;
        private Terrarium EindTerrarium;
        private Carnivore carnivore;
        private Plant plant;
        [TestInitialize]
        public void Initialize()
        {
            BeginTerrarium = new Terrarium(3, 3);
            EindTerrarium = BeginTerrarium;
        }
        [TestMethod]
        public void HerbivoreMoveRight()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(2, 1);
            carnivore = new Carnivore(begin, BeginTerrarium);
            carnivore.Move(2);
            Assert.AreEqual(end, carnivore.Position);
        }
        [TestMethod]
        public void HerbivoreMoveLeft()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(0, 1);
            carnivore = new Carnivore(begin, BeginTerrarium);
            carnivore.Move(4);
            Assert.AreEqual(end, carnivore.Position);
        }
        [TestMethod]
        public void HerbivoreMoveAbove()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 0);
            carnivore = new Carnivore(begin, BeginTerrarium);
            carnivore.Move(1);
            Assert.AreEqual(end, carnivore.Position);
        }
        [TestMethod]
        public void HerbivoreMoveBelow()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 2);
            carnivore = new Carnivore(begin, BeginTerrarium);
            carnivore.Move(3);
            Assert.AreEqual(end, carnivore.Position);
        }
    }
}
