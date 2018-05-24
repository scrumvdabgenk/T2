using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;

namespace TerraLibraryTests
{
    [TestClass]
    public class HerbivoreTests
    {
        private Terrarium BeginTerrarium;
        private Terrarium EindTerrarium;
        private Herbivore herbivore;
        private Plant plant;
        [TestInitialize]
        public void Initialize()
        {
            BeginTerrarium = new Terrarium(1, 2);
            EindTerrarium = BeginTerrarium;
            herbivore = new Herbivore();
            plant = new Plant();
        }
        [TestMethod]
        public void HerbivoreConstructorTest()
        {            
            Assert.AreEqual("H", herbivore.DisplayLetter);
        }
        [TestMethod]
        public void PlantOnRightSideOfHerbivore()
        {
            BeginTerrarium.TerrariumItems[0, 0] = herbivore;
            BeginTerrarium.TerrariumItems[0, 1] = plant;

            Assert.AreEqual(true, herbivore.CheckPlantRight());
        }
        [TestMethod]
        public void HerbivoorMoveTest()
        {
            BeginTerrarium.TerrariumItems[0, 0] = herbivore;
        }
    }
}
