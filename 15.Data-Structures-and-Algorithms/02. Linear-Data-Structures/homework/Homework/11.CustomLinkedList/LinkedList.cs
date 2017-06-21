using System;
using System.Collections;
using System.Collections.Generic;

namespace _11.CustomLinkedList
{
    public class LinkedList<T> : IEnumerable<T> where T: IComparable<T>
    {
        public Item<T> FirstElement { get; set; }

        private int CurrectCount { get; set;}


        public void Add(T element)
        {
            if(element == null)
            {
                return;
            }

            var elem = new Item<T>(element);

            if(this.CurrectCount == 0)
            {
                this.FirstElement = elem;
            }

            else
            {
                var currentElem = this.FirstElement;

                for (int i = 0; i < this.CurrectCount; i++)
                {
                    if(i == this.CurrectCount - 1)
                    {
                        currentElem.NextItem = elem;
                    }

                    currentElem = currentElem.NextItem;
                }

                this.CurrectCount++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

       
    }
}