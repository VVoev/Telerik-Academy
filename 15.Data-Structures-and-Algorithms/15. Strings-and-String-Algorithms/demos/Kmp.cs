namespace Search
{
	using System;

	class StartUp
	{
		static void Main()
		{
			string pattern = Console.ReadLine();
			string text = Console.ReadLine();

			int n = text.Length;
			int m = pattern.Length;

			if(m > n)
			{
				return;
			}

			// precompute

			int[] fl = new int[m + 1];
			fl[0] = -1;

			for(int i = 1; i < m; i++)
			{
				int j = fl[i];
				while(j >=0 && pattern[j] != pattern[i])
				{
					j = fl[j];
				}
				fl[i + 1] = j + 1;
			}

			// search
			
			int matched = 0;
			for(int i = 0; i < n; i++)
			{
				while(matched >= 0 && text[i] != pattern[matched])
				{
					matched = fl[matched];
				}

				matched++;

				if(matched == m)
				{
					Console.WriteLine("Matched at {0}", i - m + 1);
					matched = fl[matched];
				}
			}
		}
	}
}
