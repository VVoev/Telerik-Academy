using System;

namespace MatrixWalking
{
    public class ProgramMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[n, n];
            int step = n;
            int k = 1;
            int i = 0;
            int j = 0;
            int dx = 1;
            int dy = 1;
            while (true)
            { //malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[i, j] = k;
                if (!WalkInMatrix.Proverka(matrix, i, j)) { break; } // prekusvame ako sme se zadunili
                if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)


                    while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)) { WalkInMatrix.Change(ref dx, ref dy); }
                i += dx; j += dy; k++;
            }

            WalkInMatrix.FindCell(matrix, out i, out j);
            if (i != 0 && j != 0)
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                dx = 1; dy = 1;


                while (true)
                { //malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[i, j] = k;
                    if (!WalkInMatrix.Proverka(matrix, i, j)) { break; }// prekusvame ako sme se zadunili
                    if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)


                        while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)) WalkInMatrix.Change(ref dx, ref dy);
                    i += dx; j += dy; k++;
                }
            }
            for (int pp = 0; pp < n; pp++)
            {
                for (int qq = 0; qq < n; qq++) Console.Write("{0,3}", matrix[pp, qq]);

                Console.WriteLine();
            }
        }
    }
}
