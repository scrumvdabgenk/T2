using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;

namespace TerraLibraryTests
{
    [TestClass]
    public class HerbivoreTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Terrarium terrarium = new Terrarium(1, 2);
            terrarium
        }
        [TestMethod]
        public void HerbivoreConstructorTest()
        {
            Herbivore herbivore = new Herbivore();
            Assert.AreEqual("H", herbivore.DisplayLetter);
        }
        [TestMethod]
        public void HerbivoreEatsPlantOnRightSide()
        {

        }
    }
}
