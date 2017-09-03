using System;
using System.Collections.Generic;

namespace RecursionLecture
{
    public class VectorGenerator
    {
        private List<int[]> vectors;

        public List<int[]> GetAllBinaryVectors(int size)
        {
            this.vectors = new List<int[]>();
            Get01(new int[size], 0);

            return vectors;
        }

        public void GetCombinations(int[] numbers, int index, int startFrom, int end)
        {
            if (numbers.Length == index)
            {
                Console.WriteLine(string.Join(string.Empty, numbers));
                return;
            }

            for (int i = startFrom; i < end; i++)
            {
                numbers[index] = i;
                GetCombinations(numbers, index + 1, i + 1, end);
            }
        }

        public List<int[]> GetAllVectorsK(int size, int k)
        {
            this.vectors = new List<int[]>();
            this.GetVectorK(new int[size], 0, k);

            return vectors;
        }

        private void GetVectorK(int[] vector, int currentIndex, int k)
        {
            if (currentIndex == vector.Length)
            {
                int[] newVector = new int[vector.Length];
                vector.CopyTo(newVector, 0);
                this.vectors.Add(newVector);

                return;
            }

            for (int i = 0; i < k; i++)
            {
                vector[currentIndex] = i;
                this.GetVectorK(vector, currentIndex + 1, k);
            }
        }

        private void Get01(int[] vector, int currentIndex)
        {
            if (currentIndex >= vector.Length)
            {
                int[] newVector = new int[vector.Length];
                vector.CopyTo(newVector, 0);
                this.vectors.Add(newVector);

                return;
            }


            vector[currentIndex] = 0;
            Get01(vector, currentIndex + 1);

            vector[currentIndex] = 1;
            Get01(vector, currentIndex + 1);
        }
    }
}
