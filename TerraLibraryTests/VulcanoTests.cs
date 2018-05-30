using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;

namespace TerraLibraryTests
{
    [TestClass]
    public class VulcanoTests
    {
        private Terrarium testTerrarium;
        private Plant plant;
        private Herbivore herbivore;
        private Carnivore carnivore;
        private Human human;
        private Vulcano vulcano;
        private TimeController time;
        [TestInitialize]
        public void Initialize()
        {
            testTerrarium = new Terrarium(5, 5);
            plant = new Plant();
            herbivore = new Herbivore();
            carnivore = new Carnivore();
            human = new Human();
            vulcano = new Vulcano();
            time = new TimeController(0,testTerrarium); 
        }
        [TestMethod]
        public void VulcanoConstructorTest()
        {
            Vulcano vulcano = new Vulcano(new Position(1, 2));
            Assert.AreEqual(1, vulcano.Position.X);
            Assert.AreEqual(2, vulcano.Position.Y);
        }
        [TestMethod]
        public void ActivateAndKillOrganismsTest()
        {

            plant.Terrarium = testTerrarium;
            herbivore.Terrarium = testTerrarium;
            carnivore.Terrarium = testTerrarium;
            human.Terrarium = testTerrarium;
            vulcano.Position = new Position(2, 2);
            plant.Position = new Position(1, 2);
            herbivore.Position = new Position(3, 2);
            carnivore.Position = new Position(2, 1);
            human.Position= new Position(2,3);
            testTerrarium.Organisms.Add(plant);
            testTerrarium.Organisms.Add(herbivore);
            testTerrarium.Organisms.Add(carnivore);
            testTerrarium.Organisms.Add(human);
            Assert.AreEqual(4, testTerrarium.Organisms.Count);
            vulcano.ActivateAndKillOrganisms(testTerrarium, time);
            Assert.AreEqual(0, testTerrarium.Organisms.Count);
        }
    }
}
