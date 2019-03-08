using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Tests
{
    [TestClass()]
    public class LimitedListTests
    {
        [TestMethod()]
        public void NewLimitedList_Succeeds_WhenCapacityIsPositive()
        {
            // Arrange

            // Act
            var list = new LimitedList<string>(2);
            var capacity = list.Capacity;

            // Assert
            var expected = 2;
            Assert.AreEqual(expected, capacity, "list.Capacity after instanciation");
        }

        [TestMethod()]
        public void NewLimitedList_HasCapacity0_WhenInstancedWithNegativeCapacity()
        {
            // Arrange

            // Act
            var list = new LimitedList<string>(0);
            //var capacity = list.Capacity;

            // Assert
            //var expected = 2;
            //Assert.AreEqual(expected, capacity, "list.Capacity after instanciation");
            Assert.AreEqual(0, list.Capacity, "list.Capacity");
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var list = new LimitedList<string>(2);
            list.Add("1");

            // Act
            var result2 = list.Add("2");
            var result3 = list.Add("3");
            var count = list.Count;

            result3 = false;

            // Assert
            Assert.IsTrue(result2, "added last viable item"); //DÅLIGT ATT TESTA FLERA SAKER I SAMMA METOD
            Assert.IsFalse(result3, "added when at capacity");
            Assert.AreEqual(2, count, "count should be 2");

        }

        [TestMethod()]
        public void Remove_Passes_WhenItemExists()
        {
            // Arrange
            var list = new LimitedList<string>(2);
            list.Add("1");
            var result2 = list.Add("2");

            // Act
            var removeFirst = list.Remove("1");

            // Assert
            Assert.IsTrue(removeFirst, "remove returns true");
            //Assert.AreNotEqual("1", list[0], "first item is not 1");
            Assert.AreEqual("2", list[0], "1:st item becomes 0:th");
            //Assert.AreEqual(1, list.Count);
        }

        [TestMethod()]
        public void Remove_ReturnsTrue_WhenItemDoensntExists()
        {
            // Arrange
            var list = new LimitedList<string>(2);
            list.Add("1");
            list.Add("2");

            // Act
            var remove = list.Remove("3");

            // Assert
            Assert.IsFalse(remove, "remove returns false");
        }


        //[TestMethod()]
        //public void ClearTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetEnumeratorTest()
        //{
        //    Assert.Fail();
        //}
    }
}