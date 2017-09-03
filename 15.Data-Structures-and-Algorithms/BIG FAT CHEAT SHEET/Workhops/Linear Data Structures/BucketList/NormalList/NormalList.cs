using LinearDataStructuresWorkshop.BucketListStrcuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LinearDataStructuresWorkshop.NormalList
{
    public class NormalList<T> : IBucketList<T>
    {
        private List<T> list;

        public NormalList()
        {
            this.list = new List<T>();
        }

        public T this[int index]
        {
            get
            {
                return this.list[index];
            }

            set
            {
                this.list[index] = value;
            }
        }

        public int Size
        {
            get
            {
                return this.list.Count;
            }
        }

        public void Add(T value)
        {
            this.list.Add(value);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        public void Insert(int index, T value)
        {
            this.list.Insert(index, value);
        }

        public void Remove(int index)
        {
            this.list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
