using System.Collections;
using System.Collections.Generic;

namespace LinearDataStructuresWorkshop.BucketListStrcuture
{
    public class BucketList<T> : IBucketList<T>
    {
        private const int InitialBucketSize = 4;

        private List<Bucket<T>> bucketList;
        private int elementsCount;
        private int bucketSize;

        public BucketList()
        {
            this.bucketList = new List<Bucket<T>>();
            this.elementsCount = 0;
            this.bucketSize = InitialBucketSize;
        }

        public T this[int index]
        {
            get
            {
                return this.bucketList[this.AdaptBucketIndex(index)][this.AdaptIndexInBucket(index)];
            }

            set
            {
                this.bucketList[this.AdaptBucketIndex(index)][this.AdaptIndexInBucket(index)] = value;
            }
        }

        public int Size
        {
            get
            {
                return this.elementsCount;
            }
        }

        public void Add(T value)
        {
            this.Insert(this.elementsCount, value);
        }

        public void Clear()
        {
            this.bucketList = new List<Bucket<T>>();
            this.elementsCount = 0;
            this.bucketSize = InitialBucketSize;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elementsCount; i++)
            {
                yield return this[i];
            }
        }

        public void Insert(int index, T value)
        {
            if (this.bucketSize * 2 == this.bucketList.Count)
            {
                this.EnlargeBucketsSize();
            }

            int bucketIndex = this.AdaptBucketIndex(index);
            int indexInBucket = this.AdaptIndexInBucket(index);

            this.EnsureBucket();

            int currentBucketIndex = this.bucketList.Count - 1;
            int prevBucketIndex = currentBucketIndex - 1;

            while (currentBucketIndex != bucketIndex)
            {
                var prevBucketLastElement = this.bucketList[prevBucketIndex][this.bucketSize - 1];
                this.bucketList[currentBucketIndex].PushFront(prevBucketLastElement);

                currentBucketIndex--;
                prevBucketIndex--;
            }

            this.bucketList[bucketIndex].InsertAt(indexInBucket, value);
            this.elementsCount++;
        }

        public void Remove(int index)
        {
            int bucketIndex = this.AdaptBucketIndex(index);
            int indexInBucket = this.AdaptIndexInBucket(index);

            this.bucketList[bucketIndex].Remove(indexInBucket);

            int currentBucketIndex = bucketIndex;
            int nextBucketIndex = currentBucketIndex + 1;
            while (nextBucketIndex < this.bucketList.Count)
            {
                var nextBucketFirstElement = this.bucketList[nextBucketIndex].PopFront();
                this.bucketList[currentBucketIndex].PushBack(nextBucketFirstElement);

                currentBucketIndex++;
                nextBucketIndex++;
            }

            this.elementsCount--;

            if (this.bucketList[this.bucketList.Count - 1].Empty)
            {
                this.bucketList.RemoveAt(bucketList.Count - 1);

                if (this.bucketSize == this.bucketList.Count * 2)
                {
                    this.DecreaseBucketsSize();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureBucket()
        {
            if (this.bucketList.Count == 0 || this.bucketList[this.bucketList.Count - 1].Full)
            {
                var newBucket = new Bucket<T>(this.bucketSize);
                this.bucketList.Add(newBucket);
            }
        }

        private int AdaptBucketIndex(int index)
        {
            return index / this.bucketSize;
        }

        private int AdaptIndexInBucket(int index)
        {
            return index % this.bucketSize;
        }

        private void EnlargeBucketsSize()
        {
            int newBucketSize = this.bucketSize * 2;
            var newBucketList = new List<Bucket<T>>(this.bucketList.Count / 2);

            for (int i = 0; i < this.bucketList.Count; i += 2)
            {
                var bucketToAdd = new Bucket<T>(this.bucketList[i], this.bucketList[i + 1]);
                newBucketList.Add(bucketToAdd);
            }

            this.bucketSize = newBucketSize;
            this.bucketList = newBucketList;
        }

        private void DecreaseBucketsSize()
        {
            int newBucketSize = this.bucketSize / 2;
            var newBucketList = new List<Bucket<T>>();

            for (int i = 0; i < this.bucketList.Count; i++)
            {
                var leftBucket = new Bucket<T>(true, this.bucketList[i]);
                var rightBucket = new Bucket<T>(false, this.bucketList[i]);

                newBucketList.Add(leftBucket);
                newBucketList.Add(rightBucket);
            }

            this.bucketSize = newBucketSize;
            this.bucketList = newBucketList;
        }
    }
}