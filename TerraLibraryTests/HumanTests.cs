using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;
using System.Collections.Generic;

namespace TerraLibraryTests
{
    [TestClass]
    public class HumanTests
    {
        private Terrarium Terrarium;
        private Human mens;
        private Position begin;
        private Position end;
        private List<IOrganism> toDelete;

        [TestInitialize]
        public void Initialize()
        {
            Terrarium = new Terrarium(6, 6);
            begin= new Position(1, 1);
            end= new Position(2, 1);
            Terrarium = new Terrarium(3, 3);
            mens = new Human(begin, Terrarium);
            toDelete = new List<IOrganism>();
        }
        [TestMethod]
        public void MenMoveRight()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(2, 1);
            mens = new Human(begin, Terrarium);
            mens.Move(2);
            Assert.AreEqual(end, mens.Position);
        }
        [TestMethod]
        public void MenMoveLeft()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(0, 1);
            mens.Move(4);
            Assert.AreEqual(end, mens.Position);
        }
        [TestMethod]
        public void MenMoveAbove()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 0);
            mens.Move(1);
            Assert.AreEqual(end, mens.Position);
        }
        [TestMethod]
        public void MenMoveBelow()
        {
            Position begin = new Position(1, 1);
            Position end = new Position(1, 2);
            mens.Move(3);
            Assert.AreEqual(end, mens.Position);
        }
        [TestMethod]
        public void ManFightStrongCarnivore()
        {
            Position CarnivorePosition = new Position(2, 1);
            Carnivore Carnivore = new Carnivore(CarnivorePosition, Terrarium);
            Carnivore.Health = 2;
            mens.Health = 1
;            mens.Fight(Carnivore,toDelete);
            Assert.AreEqual(3, Carnivore.Health);
            Assert.IsTrue(toDelete.Contains(mens));

        }
        [TestMethod]
        public void ManFightWeakCarnivore()
        {
            Position CarnivorePosition = new Position(2, 1);
            Carnivore Carnivore = new Carnivore(CarnivorePosition, Terrarium);
            Carnivore.Health = 1;
            mens.Health = 2;
            mens.Fight(Carnivore, toDelete);
            Assert.AreEqual(3, mens.Health);
            Assert.IsTrue(toDelete.Contains(Carnivore));

        }
        [TestMethod]
        public void ManFightEqualCarnivore()
        {
            Position CarnivorePosition = new Position(2, 1);
            Carnivore Carnivore = new Carnivore(CarnivorePosition, Terrarium);
            Carnivore.Health = 2;
            mens.Health = 2;
            mens.Fight(Carnivore, toDelete);
            Assert.AreEqual(4, mens.Health);
            Assert.IsTrue(toDelete.Contains(Carnivore));

        }
    }
}
