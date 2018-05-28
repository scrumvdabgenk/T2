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
        public void FindRandomEmptyCellInTerrarium()
        {
            testTerrarium.IsEmptySpaceInTerrarium();
            Assert.
        }
    }
}
