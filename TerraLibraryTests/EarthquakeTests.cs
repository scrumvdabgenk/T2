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
            Assert.AreEqual(1, earthquake.position.X);
            Assert.AreEqual(2, earthquake.position.Y);
        }
    }
}
