using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;
using System.Collections.Generic;

namespace TerraLibraryTests
{
    [TestClass]
    public class CarnivoreTests
    {
        private Terrarium BeginTerrarium = new Terrarium(6, 6);
        private Terrarium EindTerrarium;
        private Carnivore carnivore;
        private Plant plant;
        private List<IOrganism> toDelete = new List<IOrganism>();

        [TestInitialize]
        public void Initialize()
        {
            BeginTerrarium = new Terrarium(3, 3);
            EindTerrarium = BeginTerrarium;
        }
        [TestMethod]
        public void CarnivoreMoveRight()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(2, 1);
            carnivore = new Carnivore(begin, BeginTerrarium);
            carnivore.Move(2);
            Assert.AreEqual(end, carnivore.Position);
        }
        [TestMethod]
        public void CarnivoreMoveLeft()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(0, 1);
            carnivore = new Carnivore(begin, BeginTerrarium);
            carnivore.Move(4);
            Assert.AreEqual(end, carnivore.Position);
        }
        [TestMethod]
        public void CarnivoreMoveAbove()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 0);
            carnivore = new Carnivore(begin, BeginTerrarium);
            carnivore.Move(1);
            Assert.AreEqual(end, carnivore.Position);
        }
        [TestMethod]
        public void CarnivoreMoveBelow()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 2);
            carnivore = new Carnivore(begin, BeginTerrarium);
            carnivore.Move(3);
            Assert.AreEqual(end, carnivore.Position);
        }

        [TestMethod]
        public void CarnivoreEetHerbivore()
        {
            Position carnivorePosition = new Position(1, 1);
            Position herbivorePosition = new Position(1, 2);
            Herbivore testHerbivore = new Herbivore(herbivorePosition, BeginTerrarium);
            testHerbivore.Health = 2;
            carnivore = new Carnivore(carnivorePosition, BeginTerrarium);
            carnivore.Health = 3;
            var BeginHealthCarnivore = carnivore.Health;
            var HealthHerbivore = testHerbivore.Health;
            carnivore.Eat(testHerbivore, toDelete);
            Assert.AreEqual(carnivore.Health, BeginHealthCarnivore + HealthHerbivore);
        }
        [TestMethod]
        public void StrongCarnivoreFightsWeakCarnivore()
        {
            Position carnivore1Position = new Position(1, 1);
            Position carnivore2Position = new Position(1, 2);
            Carnivore testCarnivore1 = new Carnivore(carnivore1Position, BeginTerrarium);
            Carnivore testCarnivore2 = new Carnivore(carnivore2Position, BeginTerrarium);
            testCarnivore1.Health = 2;
            testCarnivore2.Health = 1;
            testCarnivore1.Fight(testCarnivore2, toDelete);
            Assert.AreEqual(3, testCarnivore1.Health);
            Assert.IsTrue(toDelete.Contains(testCarnivore2));
        }

        [TestMethod]
        public void WeakCarnivoreFightsStrongCarnivore()
        {
            toDelete.Clear();
            Position carnivore1Position = new Position(1, 1);
            Position carnivore2Position = new Position(1, 2);
            Carnivore testCarnivore1 = new Carnivore(carnivore1Position, BeginTerrarium);
            Carnivore testCarnivore2 = new Carnivore(carnivore2Position, BeginTerrarium);
            testCarnivore1.Health = 1;
            testCarnivore2.Health = 2;
            testCarnivore1.Fight(testCarnivore2, toDelete);
            Assert.AreEqual(1, testCarnivore1.Health);
            Assert.IsTrue(toDelete.Contains(testCarnivore1));
            Assert.AreEqual(1, toDelete.Count);
        }
        [TestMethod]
        public void EqualCarnivoresFight()
        {
            toDelete.Clear();
            Position carnivore1Position = new Position(1, 1);
            Position carnivore2Position = new Position(1, 2);
            Carnivore testCarnivore1 = new Carnivore(carnivore1Position, BeginTerrarium);
            Carnivore testCarnivore2 = new Carnivore(carnivore2Position, BeginTerrarium);
            testCarnivore1.Health = 2;
            testCarnivore2.Health = 2;
            testCarnivore1.Fight(testCarnivore2, toDelete);
            Assert.AreEqual(2, testCarnivore1.Health);
            Assert.AreEqual(2, testCarnivore2.Health);
            Assert.AreEqual(0,toDelete.Count);
        }
        [TestMethod]
        public void CanivoreFightStrongMan()
        {
            toDelete.Clear();
            Position carnivorePosition = new Position(1, 1);
            Position manPosition = new Position(2, 1);
            Carnivore carnivore = new Carnivore(carnivorePosition, BeginTerrarium);
            Human man = new Human(manPosition, BeginTerrarium);
            man.Health = 2;
            carnivore.Health = 1;
            carnivore.Fight(man, toDelete);
            Assert.AreEqual(3, man.Health);
            Assert.IsTrue(toDelete.Contains(carnivore));
        }
        [TestMethod]
        public void CanivoreFightWeakMan()
        {
            toDelete.Clear();
            Position carnivorePosition = new Position(1, 1);
            Position manPosition = new Position(2, 1);
            Carnivore carnivore = new Carnivore(carnivorePosition, BeginTerrarium);
            Human man = new Human(manPosition, BeginTerrarium);
            man.Health = 1;
            carnivore.Health = 2;
            carnivore.Fight(man, toDelete);
            Assert.AreEqual(3, carnivore.Health);
            Assert.IsTrue(toDelete.Contains(man));
        }
    }
}
