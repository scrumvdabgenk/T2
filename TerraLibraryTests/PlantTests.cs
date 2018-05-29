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
            Assert.AreEqual(1, new Plant(new Position(1,1),testTerrarium).Health);
        }
    }
   
}
