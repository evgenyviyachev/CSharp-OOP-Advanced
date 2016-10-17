namespace Database.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DatabaseTests
    {
        private Database database;
        private Person[] array;

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConstructorWithArrayCapacityMoreThan16ShouldThrow()
        {
            this.array = new Person[17];
            this.database = new Database(this.array);
        }

        [TestMethod]
        public void ConstructorWithArrayCapacity16ShouldNotThrow()
        {
            this.array = new Person[16];
            this.database = new Database(this.array);
            Assert.IsTrue(this.database.Collection.Length == 16);
        }

        [TestMethod]
        public void AddWithTwoElementsShouldAddOne()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.Add(new Person("Gosho", 3));
            Assert.AreEqual(null, this.database.Collection[3]);
            Assert.AreNotEqual(null, this.database.Collection[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddWith16ElementsShouldThrow()
        {
            this.array = new Person[16];
            this.database = new Database(this.array);
            this.database.Add(new Person("Gosho", 3));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddWithSameUsernameShouldThrow()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.Add(new Person("Ivan", 3));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddWithSameIdShouldThrow()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.Add(new Person("Gosho", 1));
        }

        [TestMethod]
        public void RemoveFromTwoShouldBecomeOne()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.Remove();
            Assert.AreEqual(1, this.database.Collection.Count(n => n != null));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFromEmptyShouldThrow()
        {
            this.array = new Person[] { };
            this.database = new Database(this.array);
            this.database.Remove();
        }

        [TestMethod]
        public void FindByUsernameShouldWorkCorrectly()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            Person person = this.database.FindByUsername("Ivan");
            Assert.AreEqual(person, this.database.Collection[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindByUsernameShouldThrowWhenInexistingUsernameIsPresented()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.FindByUsername("Tosho");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindByUsernameShouldThrowWhenCaseInsensitiveUsernameIsPresented()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.FindByUsername("ivan");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindByUsernameShouldThrowWhenNullIsPresented()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.FindByUsername(null);
        }

        [TestMethod]
        public void FindByIdShouldWorkCorrectly()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            Person person = this.database.FindById(1);
            Assert.AreEqual(person, this.database.Collection[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindByIdShouldThrowWhenInexistingIdIsPresented()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.FindById(8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindByIdShouldThrowWhenNegativeIdIsPresented()
        {
            this.array = new Person[] { new Person("Ivan", 1), new Person("Pesho", 2) };
            this.database = new Database(this.array);
            this.database.FindById(-1);
        }
    }
}
