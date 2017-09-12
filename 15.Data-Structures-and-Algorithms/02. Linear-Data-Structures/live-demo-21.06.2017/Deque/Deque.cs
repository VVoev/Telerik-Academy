﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Deque
{
    public class Deque<T> : IEnumerable<T>
    {
        private const int MIN_CAPACITY = 4;

        private T[] buffer;
        private int startIndex;
        private int size;
        private int endIndex;

        public Deque()
        {
            buffer = null;
            startIndex = 0;
            size = 0;
            endIndex = 0;
        }

        public int Size => size;
        public bool Empty => size == 0;
        public int Capacity => buffer.Length;
        public T Front => buffer[startIndex];
        public T Back => buffer[PrevIndex(endIndex)];

        public void PushBack(T value)
        {
            MakeSpaceForOneMoreIfNeeded();

            buffer[endIndex] = value;
            endIndex = NextIndex(endIndex);
            ++size;
        }

        public void PushFront(T value)
        {
            MakeSpaceForOneMoreIfNeeded();

            startIndex = PrevIndex(startIndex);
            buffer[startIndex] = value;
            ++size;
        }

        public void PopBack()
        {
            endIndex = PrevIndex(endIndex);
            buffer[endIndex] = default(T);
            --size;
        }

        public void PopFront()
        {
            buffer[startIndex] = default(T);
            startIndex = NextIndex(startIndex);
            --size;
        }

        public void Reserve(int newSize)
        {
            if (newSize < size)
            {
                return;
            }

            var newBuffer = new T[newSize];

            for (int i = 0, j = startIndex;
                i < size;
                ++i, j = NextIndex(j))
            {
                newBuffer[i] = buffer[j];
            }

            startIndex = 0;
            endIndex = size;
            buffer = newBuffer;
        }

        private int NextIndex(int index)
        {
            ++index;
            if (index == buffer.Length)
            {
                index = 0;
            }
            return index;
        }

        private int PrevIndex(int index)
        {
            if (index == 0)
            {
                index = buffer.Length;
            }
            --index;
            return index;
        }

        private void MakeSpaceForOneMoreIfNeeded()
        {
            if (buffer == null)
            {
                buffer = new T[MIN_CAPACITY];
            }
            else if (size == buffer.Length)
            {
                Reserve(size * 2);
            }
        }

        public T this[int index]
        {
            get
            {
                return buffer[AdaptIndex(index)];
            }
            set
            {
                buffer[AdaptIndex(index)] = value;
            }
        }

        private int AdaptIndex(int index)
        {
            int realIndex = startIndex + index;
            if(realIndex >= buffer.Length)
            {
                realIndex -= buffer.Length;
            }

            return realIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = startIndex, j = 0;
                j < size;
                i = NextIndex(i), ++j)
            {
                yield return buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
