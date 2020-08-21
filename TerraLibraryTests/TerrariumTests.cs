using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraLibrary;

namespace TerraLibraryTests
{
    [TestClass]
    public class TerrariumTests
    {
        private Terrarium testTerrarium;
        [TestInitialize]
        public void Initialize()
        {
            testTerrarium = new Terrarium(6, 6);
        }
        [TestMethod]
        public void TerrariumConstructortest()
        {
            testTerrarium = new Terrarium(4, 5);
            Assert.AreEqual(4, testTerrarium.Width);
            Assert.AreEqual(5, testTerrarium.Height);
        }
    }
}
