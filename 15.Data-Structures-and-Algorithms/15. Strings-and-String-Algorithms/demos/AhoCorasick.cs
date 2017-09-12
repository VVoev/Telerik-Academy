namespace Search
{
	using System;
	using System.Collections.Generic;

	class StartUp
	{
		static void Main()
		{
			Node root = new Node();

			string[] patterns = Console.ReadLine().Split(' ');

			// Build tree

			for(int i = 0; i < patterns.Length; i++)
			{
				Node x = root;
				foreach(char c in patterns[i])
				{
					if(x.Letter[c - 'a'] == null)
					{
						x.Letter[c - 'a'] = new Node();
					}

					x = x.Letter[c - 'a'];
				}
				x.Index = i;
			}

			// Compute fail links

			Queue<Node> q = new Queue<Node>();

			q.Enqueue(root);
			while(q.Count > 0)
			{
				Node x = q.Dequeue();

				if(x.faillink != null)
				{
					if(x.faillink.Index >= 0)
					{
						x.successlink = x.faillink;
					}
					else if(x.faillink.successlink != null)
					{
						x.successlink = x.faillink.successlink;
					}
				}

				for(int i = 0; i < 26; i++)
				{
					if(x.Letter[i] == null)
					{
						continue;
					}

					q.Enqueue(x.Letter[i]);

					Node y = x.faillink;
					while(y != null && y.Letter[i] == null)
					{
						y = y.faillink;
					}

					x.Letter[i].faillink = (y == null) ? root : y.Letter[i];
				}
			}

			// Search

			string text = Console.ReadLine();

			int n = text.Length;

			Node matched = root;
			for(int i = 0; i < n; i++)
			{
				while(matched != null && matched.Letter[text[i] - 'a'] == null)
				{
					matched = matched.faillink;
				}

				matched = (matched == null) ? root : matched.Letter[text[i] - 'a'];

				if(matched.Index >= 0)
				{
					Console.WriteLine("{0} matches at {1}", patterns[matched.Index], i - patterns[matched.Index].Length + 1);
				}

				for(Node x = matched.successlink; x != null; x = x.successlink)
				{
					Console.WriteLine("{0} matches at {1}", patterns[x.Index], i - patterns[x.Index].Length + 1);
				}
			}
		}
	}

	class Node
	{
		public Node[] Letter { get; set; }
		public Node faillink { get; set; }
		public Node successlink { get; set; }
		public int Index { get; set; }

		public Node()
		{
			this.Letter = new Node[26];
			this.Index = -1;
		}
	}
}
