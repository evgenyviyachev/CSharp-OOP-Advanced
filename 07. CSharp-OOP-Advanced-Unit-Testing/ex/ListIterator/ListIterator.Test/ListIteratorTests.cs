namespace ListIterator.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListIteratorTests
    {
        private List<string> list;
        private IterableCollection collection;

        [TestInitialize]
        public void Init()
        {
            this.list = new List<string>();
        }

        [TestMethod]
        public void ConstructorShouldNotThrowWithEmptyCollection()
        {
            this.collection = new IterableCollection(this.list);
            Assert.IsTrue(this.collection.Collection.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorShouldThrowWithNullCollection()
        {
            this.list = null;
            this.collection = new IterableCollection(this.list);
        }

        [TestMethod]
        public void OneMoveWithTwoElementsShouldReturnTrue()
        {
            this.list.Add("Pesho");
            this.list.Add("Stamat");
            this.collection = new IterableCollection(this.list);
            bool hasMoved = this.collection.Move();
            Assert.IsTrue(hasMoved);
        }

        [TestMethod]
        public void TwoMovesWithTwoElementsShouldReturnFalse()
        {
            this.list.Add("Pesho");
            this.list.Add("Stamat");
            this.collection = new IterableCollection(this.list);
            this.collection.Move();
            bool hasMoved = this.collection.Move();
            Assert.IsFalse(hasMoved);
        }

        [TestMethod]
        public void OneMoveShouldMoveInternalIndexByOne()
        {
            this.list.Add("Pesho");
            this.list.Add("Stamat");
            this.collection = new IterableCollection(this.list);
            int beforeMove = this.collection.CurrentIndex;
            this.collection.Move();
            int afterMove = this.collection.CurrentIndex;
            Assert.AreEqual(0, beforeMove);
            Assert.AreEqual(1, afterMove, "Move() doesn't move the internal index!");
        }

        [TestMethod]
        public void HasNextWithTwoElementsShouldReturnTrue()
        {
            this.list.Add("Pesho");
            this.list.Add("Stamat");
            this.collection = new IterableCollection(this.list);
            bool hasNext = this.collection.HasNext();
            Assert.IsTrue(hasNext);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PrintMethodOnEmptyCollectionShouldThrow()
        {
            this.collection = new IterableCollection(this.list);
            this.collection.Print();
        }
    }
}
