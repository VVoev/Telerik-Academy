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

			for(int i = 0; i <= n - m; i++)
			{
				int matched = 0;

				while(matched < m)
				{
					if(text[i + matched] != pattern[matched])
					{
						break;
					}

					matched++;
				}

				if(matched == m)
				{
					Console.WriteLine("Match at {0}", i);
				}
			}
		}
	}
}
