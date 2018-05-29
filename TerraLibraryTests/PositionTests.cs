using System;
using TerraLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TerraLibraryTests
{
    [TestClass]
    public class PositionTests
    {
        private Terrarium terrarium;
        [TestInitialize]
        public void Initialize()
        {
            terrarium = new Terrarium(1, 1);
        }
        [TestMethod]
        public void PositionConstructorTest()
        {
            Position position = new Position(1, 2);
            Assert.AreEqual(1, position.X);
            Assert.AreEqual(2, position.Y);
        }
        [TestMethod]
        public void PositionGenerateRandomEmptyPositionTestPass()
        {
            Position pos1 = new Position(0,0);
            Assert.AreEqual(pos1,Position.GenerateRandomEmptyPosition(terrarium));
        }
        [TestMethod]
        public void PositionGenerateRandomEmptyPositionTestFail()
        {
            Position pos1 = new Position(0, 0);
            terrarium.Organisms.Add(new Plant(pos1, terrarium));
            Assert.AreEqual(null,Position.GenerateRandomEmptyPosition(terrarium));
        }
    }
}
