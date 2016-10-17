namespace ListIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IterableCollection
    {
        private List<string> collection;
        private int currentIndex = 0;

        public IterableCollection(List<string> collection)
        {
            this.Collection = collection;
        }

        public List<string> Collection
        {
            get
            {
                return this.collection;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.collection = value;
            }
        }

        public int CurrentIndex
        {
            get
            {
                return this.currentIndex;
            }
        }

        public bool Move()
        {
            if (this.currentIndex + 1 < this.collection.Count())
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex + 1 < this.collection.Count())
            {
                return true;
            }
            return false;
        }

        public string Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return this.collection[this.currentIndex];
        }
    }
}
