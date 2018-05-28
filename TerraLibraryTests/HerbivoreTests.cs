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
        private Plant plant;
        private List<Organism> TestList=new List<Organism>();
        private List<Organism> EindList= new List<Organism>();
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
        public void HerbivoreEats()
        {
            herbivore = new Herbivore(new Position(1, 1), BeginTerrarium);
            plant = new Plant(new Position(2, 1), BeginTerrarium);
            TestList.Add(plant);
            herbivore.Eat(plant,EindList);
            EindList.Exists(plant);
        }
    }
}
