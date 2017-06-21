using System;
using System.Collections.Generic;

namespace Linear_Data_StructuresHomework
{
    public class Homework
    {

        static void Main()
        {
           
        }

        private static void PrintFiftyNumbersInQuque(int number)
        {
            int limit = 50;
            var tail = new Queue<int>();
            for (int i = 0; i < limit; i++)
            {
                if (i == 0)
                {
                    tail.Enqueue(number);
                }
                Console.WriteLine(tail.Peek());
            }
        }

        private static void FindHowManyTimesOccur(List<int> sequence4)
        {
            var count = 1;
            var vulk = new List<int>();
            for (int i = 0; i < sequence4.Count-1; i++)
            {
                for (int j = i+1; j < sequence4.Count; j++)
                {
                    if(sequence4[i] == sequence4[j])
                    {
                        count++;
                    }
                }

                if (!vulk.Contains(sequence4[i]))
                {
                    vulk.Add(sequence4[i]);
                    Console.WriteLine($"Number {sequence4[i]} occur {count} times");
                }

                count = 1;
            }
        }

        private static void RemoveAllNumberThatOccurOddTimes(List<int> sequence)
        {
            var counter = 1;
            var vulk = new List<int>();
            for (int i = 0; i < sequence.Count-1; i++)
            {
                for (int j = i+1; j < sequence.Count; j++)
                {
                    if(sequence[i] == sequence[j])
                    {
                        counter++;
                    }
                }

                if(counter%2 == 1)
                {
                    
                }
                else
                {
                    vulk.Add(sequence[i]);
                }

                counter = 1;
            }

            Console.WriteLine(string.Join(" " ,vulk));
        }

        private static List<int> RemoveAllNegativeNumbers(List<int> sequence3)
        {
            for (int i = 0; i < sequence3.Count; i++)
            {
                if(sequence3[i] < 0)
                {
                    sequence3.RemoveAt(i);
                }
            }
            return sequence3;
        }

        private static void FindLongestSubsequenceOfGivenNumbers(List<int> sequence)
        {
            var counter = 1;
            var bestCounter = 1;
            var number = -9999;
            var vulk = new List<int>();
            for (int i = 0; i < sequence.Count - 1; i++)
            {
                for (int j = i + 1; j < sequence.Count; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        counter++;
                        if (counter > bestCounter)
                        {
                            if (vulk.Count>0)
                            {
                                vulk.Clear();
                            }
                            bestCounter = counter;
                            vulk.Add(counter);
                            number = sequence[i];
                        }
                    }

                }

                counter = 1;
            }
            Console.Write("maximum matches ");
            Console.WriteLine(string.Join("", vulk));
            Console.WriteLine($"Number is {number}");
        }

        private static void SortListInIncreasingOrder(List<int> sequence)
        {
            for (int i = 0; i < sequence.Count - 1; i++)
            {
                for (int j = i + 1; j < sequence.Count; j++)
                {
                    if (sequence[i] > sequence[j])
                    {
                        int temp = sequence[i];
                        sequence[i] = sequence[j];
                        sequence[j] = temp;
                    }
                }
            }
            Console.WriteLine("Lets sort the fuckin list");
            Console.WriteLine(string.Join(" ", sequence));
        }

        private static void PrintStack(Stack<int> stack)
        {
            Console.WriteLine($"Print the items in reverse order");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        private static void FillStack(Stack<int> stack, int[] sequence)
        {
            foreach (var item in sequence)
            {
                stack.Push(item);
            }
        }

        private static void AverageSum(int[] sequence)
        {
            double sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
            }
            Console.WriteLine($"Average sum is {sum / sequence.Length}");
        }

        private static void CalculateSum(int[] sequence)
        {
            int sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
            }
            Console.WriteLine($"Total sum is {sum}");
        }
    }
}
