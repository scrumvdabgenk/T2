using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;
using System.Collections.Generic;

namespace TerraLibraryTests
{
    [TestClass]
    public class HerbivoreTests
    {
        private Terrarium BeginTerrarium;
        private Terrarium EindTerrarium;
        private Herbivore herbivore;
        private Carnivore carnivore;
        private Plant testPlant;
        private List<Organism> TestList = new List<Organism>();
        private List<Organism> EindList = new List<Organism>();
        private List<Organism> toDelete = new List<Organism>();
        private List<Organism> toAdd = new List<Organism>();

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
            herbivore = new Herbivore(begin, BeginTerrarium);
            herbivore.Move(2);
            Assert.AreEqual(end, herbivore.Position);
        }
        [TestMethod]
        public void HerbivoreMoveLeft()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(0, 1);
            herbivore = new Herbivore(begin, BeginTerrarium);
            herbivore.Move(4);
            Assert.AreEqual(end, herbivore.Position);
        }
        [TestMethod]
        public void HerbivoreMoveAbove()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 0);
            herbivore = new Herbivore(begin, BeginTerrarium);
            herbivore.Move(1);
            Assert.AreEqual(end, herbivore.Position);
        }
        [TestMethod]
        public void HerbivoreMoveBelow()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 2);
            herbivore = new Herbivore(begin, BeginTerrarium);
            herbivore.Move(3);
            Assert.AreEqual(end, herbivore.Position);
        }

        [TestMethod]
        public void HerbivoreEatsPlant()
        {
            toDelete.Clear();
            Position herbivorePosition = new Position(1, 1);
            Position plantPosition = new Position(2, 1);
            herbivore = new Herbivore(herbivorePosition, BeginTerrarium);
            testPlant = new Plant(plantPosition, BeginTerrarium);
            var health = herbivore.Health;
            herbivore.Eat(testPlant, toDelete);
            // health moet met één verhogen als plant wordt gegeten
            Assert.AreEqual(health + 1, herbivore.Health);
            Assert.IsTrue(toDelete.Contains(testPlant));
        }

        [TestMethod]
        public void HerbivoresBreedAndAddNewHerbivore()
        {
            toAdd.Clear();
            Position herbivore1Position = new Position(1, 1);
            Position herbivore2Position = new Position(2, 1);
            Herbivore herbivore1 = new Herbivore(herbivore1Position, BeginTerrarium);
            Herbivore herbivore2 = new Herbivore(herbivore2Position, BeginTerrarium);
            herbivore1.Breed(toAdd);
            Assert.AreEqual(1, toAdd.Count); // test of nieuwe herbivoor is aangemaakt
          
        }
    }
}
