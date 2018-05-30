using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;

namespace TerraLibraryTests
{
    [TestClass]
    public class EarthquakeTests
    {
        private Terrarium testTerrarium;
        private Plant plant;
        private Herbivore herbivore;
        private Carnivore carnivore;
        private Human human;
        private EarthQuake earthquake;
        private TimeController time;
        [TestInitialize]
        public void Initialize()
        {
            testTerrarium = new Terrarium(5, 5);
            plant = new Plant();
            herbivore = new Herbivore();
            carnivore = new Carnivore();
            human = new Human();
            earthquake = new EarthQuake();
            time = new TimeController(0, testTerrarium);
        }
        [TestMethod]
        public void EarthQuakeConstructorTest()
        {
            earthquake = new EarthQuake(new Position(1, 2));
            Assert.AreEqual(1, earthquake.Position.X);
            Assert.AreEqual(2, earthquake.Position.Y);
        }
        [TestMethod]
        public void EarthQuakeActivateTest()
        {
            Position pos1 = new Position(1, 2);
            Position pos2 = new Position(3, 2);
            Position pos3 = new Position(2, 1);
            Position pos4 = new Position(2, 3);
            plant.Terrarium = testTerrarium;
            herbivore.Terrarium = testTerrarium;
            carnivore.Terrarium = testTerrarium;
            human.Terrarium = testTerrarium;
            earthquake.Position = new Position(2, 2);
            plant.Position = pos1;
            herbivore.Position = pos2;
            carnivore.Position = pos3;
            human.Position = pos4;
            testTerrarium.Organisms.Add(plant);
            testTerrarium.Organisms.Add(herbivore);
            testTerrarium.Organisms.Add(carnivore);
            testTerrarium.Organisms.Add(human);
            earthquake.Activate(testTerrarium, time);
            Assert.AreNotEqual(pos1, plant.Position);
            Assert.AreNotEqual(pos2, herbivore.Position);
            Assert.AreNotEqual(pos3, carnivore.Position);
            Assert.AreNotEqual(pos4, human.Position);
        }
    }
}
