using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;
using System.Collections.Generic;

namespace TerraLibraryTests
{
    [TestClass]
    public class MensTesten
    {
        private Terrarium BeginTerrarium = new Terrarium(6, 6);
        private Terrarium EindTerrarium;
        private Mens mens;
       
        private List<Organism> toDelete = new List<Organism>();

        [TestInitialize]
        public void Initialize()
        {
            BeginTerrarium = new Terrarium(3, 3);
            EindTerrarium = BeginTerrarium;
        }
        [TestMethod]
        public void MenMoveRight()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(2, 1);
            mens = new Mens(begin, BeginTerrarium);
            mens.Move(2);
            Assert.AreEqual(end, mens.Position);
        }
        [TestMethod]
        public void MenMoveLeft()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(0, 1);
            mens = new Mens(begin, BeginTerrarium);
            mens.Move(4);
            Assert.AreEqual(end, mens.Position);
        }
        [TestMethod]
        public void MenMoveAbove()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 0);
            mens = new Mens(begin, BeginTerrarium);
            mens.Move(1);
            Assert.AreEqual(end, mens.Position);
        }
        [TestMethod]
        public void MenMoveBelow()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 2);
            mens = new Mens(begin, BeginTerrarium);
            mens.Move(3);
            Assert.AreEqual(end, mens.Position);
        }
        [TestMethod]
        public void ManFightStrongCarnivore()
        {
            Position ManPosition = new Position(1, 1);
            Position CarnivorePosition = new Position(2, 1);
            Mens Man = new Mens(ManPosition, BeginTerrarium);
            Carnivore Carnivore = new Carnivore(CarnivorePosition, BeginTerrarium);
            Carnivore.Health = 2;
            mens.Health = 1;
            Man.Fight(Carnivore,toDelete);
            Assert.AreEqual(3, Carnivore.Health);
            Assert.IsTrue(toDelete.Contains(mens));

        }
        [TestMethod]
        public void ManFightWeakCarnivore()
        {
            Position ManPosition = new Position(1, 1);
            Position CarnivorePosition = new Position(2, 1);
            Mens Man = new Mens(ManPosition, BeginTerrarium);
            Carnivore Carnivore = new Carnivore(CarnivorePosition, BeginTerrarium);
            Carnivore.Health = 1;
            mens.Health = 2;
            Man.Fight(Carnivore, toDelete);
            Assert.AreEqual(3, Man.Health);
            Assert.IsTrue(toDelete.Contains(Carnivore));

        }
    }
}
