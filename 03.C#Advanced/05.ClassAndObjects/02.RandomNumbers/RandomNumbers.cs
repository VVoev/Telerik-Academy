using System;

class RandomNumbers
{
    static void Main()
    {
        int[] randomNumbersArray = new int[10];
        Random rnd = new Random();

        for (int i = 0; i < randomNumbersArray.Length; i++)
        {
            int randomNumber = rnd.Next(100, 200);
            randomNumbersArray[i] = randomNumber;
        }

        Console.WriteLine(string.Join(Environment.NewLine,randomNumbersArray));
    }
}
