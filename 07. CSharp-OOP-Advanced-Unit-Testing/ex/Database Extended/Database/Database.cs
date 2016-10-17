using System;
using System.Linq;

namespace Database
{
    public class Database
    {
        private Person[] collection;
        private int currentIndex = 0;

        public Database(Person[] collection)
        {
            this.Collection = collection;
        }

        public Person[] Collection
        {
            get
            {
                return this.collection;
            }
            set
            {
                this.collection = new Person[16];

                if (value.Length > 16)
                {
                    throw new InvalidOperationException();
                }

                for (int i = 0; i < value.Length; i++)
                {
                    this.collection[i] = value[i];
                }

                this.currentIndex = value.Length;
            }
        }

        public int CurrentIndex
        {
            get
            {
                return this.currentIndex;
            }
        }

        public void Add(Person person)
        {
            if (this.currentIndex > 15)
            {
                throw new InvalidOperationException();
            }

            var peopleToCheck = this.collection.Where(p => p != null);

            if (peopleToCheck.Any(p => p.Username == person.Username
                || p.Id == person.Id))
            {
                throw new InvalidOperationException();
            }

            this.collection[this.currentIndex] = person;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex < 1)
            {
                throw new InvalidOperationException();
            }

            this.currentIndex--;
            this.collection[this.currentIndex] = null;
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            var peopleToCheck = this.collection.Where(p => p != null);

            if (!peopleToCheck.Any(p => p.Username == username))
            {
                throw new InvalidOperationException();
            }

            return peopleToCheck.FirstOrDefault(p => p.Username == username);
        }

        public Person FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var peopleToCheck = this.collection.Where(p => p != null);

            if (!peopleToCheck.Any(p => p.Id == id))
            {
                throw new InvalidOperationException();
            }

            return peopleToCheck.FirstOrDefault(p => p.Id == id);
        }
    }
}
