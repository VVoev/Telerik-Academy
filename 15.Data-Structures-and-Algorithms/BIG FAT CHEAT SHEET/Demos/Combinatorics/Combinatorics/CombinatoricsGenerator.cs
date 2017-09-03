namespace Combinatorics
{
    public class CombinatoricsGenerator
    {
        public void GenerateVariationsWithRepetitions(int n, int k)
        {
            var variations = new int[k];
            this.GenerateVariationsWithRepetitions(variations, 0, n);
        }

        public void GenerateVariationsWithoutRepetitions(int n, int k)
        {
            var variations = new int[k];
            var visited = new bool[n];

            this.GenerateVariationsWithoutRepetitions(variations, visited, 0);
        }

        private void GenerateVariationsWithoutRepetitions(int[] variations, bool[] visited, int index)
        {
            if (index == variations.Length)
            {
                Print(variations);
                return;
            }

            for (int i = 0; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    variations[index] = i;
                    visited[i] = true;

                    this.GenerateVariationsWithoutRepetitions(variations, visited, index + 1);
                    visited[i] = false;
                }
            }
        }

        private void GenerateVariationsWithRepetitions(int[] variations, int index, int n)
        {
            if (index == variations.Length)
            {
                Print(variations);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                variations[index] = i;
                GenerateVariationsWithRepetitions(variations, index + 1, n);
            }
        }

        public void GenerateCombinations(int n, int k)
        {
            int[] combinations = new int[k];
            this.GenerateCombinations(combinations, 0, 0, n);
        }

        private void GenerateCombinations(int[] combinations, int index, int start, int n)
        {
            if (index >= combinations.Length)
            {
                Print(combinations);
                return;
            }

            for (int i = start; i < n; i++)
            {
                combinations[index] = i;
                GenerateCombinations(combinations, index + 1, i + 1, n);
            }
        }

        public void GenerateCombinationsWithRepetition(int n, int k)
        {
            int[] combinations = new int[k];
            this.GenerateCombinationsWithRepetition(combinations, 0, 0, n);
        }

        private void GenerateCombinationsWithRepetition(int[] combinations, int index, int start, int n)
        {
            if (index >= combinations.Length)
            {
                Print(combinations);
                return;
            }

            for (int i = start; i < n; i++)
            {
                combinations[index] = i;
                GenerateCombinations(combinations, index + 1, i, n);
            }
        }

        private void Print<T>(T[] arr)
        {
            System.Console.WriteLine(string.Join(", ", arr));
        }
    }
}
