using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DP_Guitar
{
    class Program
    {
        static void Main(string[] args)
        {
            //int CNumberOfSongs = int.Parse(Console.ReadLine());
            string[] volumesAsString = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] volumesInteger = new int[volumesAsString.Length];
            for (int i = 0; i < volumesAsString.Length; i++)
            {
                volumesInteger[i] = int.Parse(volumesAsString[i]);
            }

            int bStart = int.Parse(Console.ReadLine());
            int MMax = int.Parse(Console.ReadLine());

            var dpMatrix = new int[volumesInteger.Length+1, MMax + 1];
            dpMatrix[0, bStart] = 1;

            for (int currentVolumeChange = 1; currentVolumeChange <= volumesInteger.Length; currentVolumeChange++)
            {
                for (int possibleVolume = 0; possibleVolume <= MMax; possibleVolume++)
                {
                    if (dpMatrix[currentVolumeChange - 1, possibleVolume] == 1)
                    {
                        int newPossibleVolume = possibleVolume - volumesInteger[currentVolumeChange - 1];
                        if (newPossibleVolume >= 0)
                        {
                            dpMatrix[currentVolumeChange, newPossibleVolume] = 1;
                        }
                        newPossibleVolume = possibleVolume + volumesInteger[currentVolumeChange - 1];
                        if(newPossibleVolume <= MMax)
                        {
                            dpMatrix[currentVolumeChange, newPossibleVolume] = 1;
                        }
                    }
                }
            }

            for (int i = MMax; i >= 0; i--)
            {
                if(dpMatrix[volumesInteger.Length,i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine(-1);
        }

    }
}
    