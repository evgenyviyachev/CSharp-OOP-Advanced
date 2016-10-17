namespace Database.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class DatabaseTests
    {
        private Database database;
        private int?[] array;

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConstructorWithArrayCapacityMoreThan16ShouldThrow()
        {
            this.array = new int?[17];
            this.database = new Database(this.array);
        }

        [TestMethod]
        public void ConstructorWithArrayCapacity16ShouldNotThrow()
        {
            this.array = new int?[16];
            this.database = new Database(this.array);
            Assert.IsTrue(this.database.Collection.Length == 16);
        }

        [TestMethod]
        public void AddWithTwoElementsShouldAddOne()
        {
            this.array = new int?[] { 2, 3 };
            this.database = new Database(this.array);
            this.database.Add(4);
            Assert.AreEqual(4, this.database.Collection[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddWith16ElementsShouldThrow()
        {
            this.array = new int?[16];
            this.database = new Database(this.array);
            this.database.Add(4);
        }

        [TestMethod]
        public void RemoveFromTwoShouldBecomeOne()
        {
            this.array = new int?[] { 2, 3 };
            this.database = new Database(this.array);
            this.database.Remove();
            Assert.AreEqual(1, this.database.Collection.Count(n => n != null));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFromEmptyShouldThrow()
        {
            this.array = new int?[] { };
            this.database = new Database(this.array);
            this.database.Remove();
        }

        [TestMethod]
        public void FetchMethodReturnsArray()
        {
            this.array = new int?[] { 2, 3 };
            this.database = new Database(this.array);
            Assert.IsTrue(this.database.Fetch() is int[]);
        }
    }    
}
