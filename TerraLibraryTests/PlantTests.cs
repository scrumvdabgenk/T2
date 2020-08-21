using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;

namespace TerraLibraryTests

{
    [TestClass]
    public class PlantTests
    {
        [TestMethod]
        public void NieuwePlantHeeftLevenskrachtEen()
        {
            Terrarium testTerrarium = new Terrarium(3,3);
            Plant plant = new Plant();
            plant.Position = new Position(1, 1);
            plant.Terrarium = testTerrarium;
            Assert.AreEqual(1, plant.Health);
        }
    }
   
}
