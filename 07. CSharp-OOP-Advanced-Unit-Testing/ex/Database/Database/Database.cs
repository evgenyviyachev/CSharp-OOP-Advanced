using System;
using System.Linq;

namespace Database
{
    public class Database
    {
        private int?[] collection;
        private int currentIndex = 0;

        public Database(int?[] collection)
        {
            this.Collection = collection;
        }

        public int?[] Collection
        {
            get
            {
                return this.collection;
            }
            set
            {
                this.collection = new int?[16];

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

        public void Add(int num)
        {
            if (this.currentIndex > 15)
            {
                throw new InvalidOperationException();
            }

            this.collection[this.currentIndex] = num;
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

        public int[] Fetch()
        {
            return this.collection
                .Where(n => n != null)
                .Select(n => n ?? default(int)).ToArray();
        }
    }
}
