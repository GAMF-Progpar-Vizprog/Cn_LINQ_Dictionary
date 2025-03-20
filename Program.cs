using System;
using System.Collections.Generic;
using System.Linq;

namespace CnLINQDictionary
{
	/// <summary>
	/// A simple program implementing some dictionary functions, aimed at demonstrating
	/// the use of LINQ to objects. We store word pairs in a generic list object,
	/// then query which pairs contain the word "nice" on the English side, further
	/// filter the result set based on size, and produce the output sorted alphabetically
	/// by the Hungarian words.
	/// </summary>


	/// <summary>
	/// Class for storing word pairs.
	/// </summary>
	class WordPairs
	{
		public string English { get; set; }
		public string Hungarian { get; set; }
		public WordPairs(string en, string hu)
		{
			English = en;
			Hungarian = hu;
		}
	}

	/// <summary>
	/// This class contains the main method.
	/// </summary>
	class Program
	{
		/// <summary>
		/// Generic list for storing word pairs.
		/// </summary>
		static List<WordPairs> WordPairList = new List<WordPairs>();

		/// <summary>
		/// Main method.
		/// </summary>
		static void Main(string[] args)
		{
			// Populate the list with word pairs.
			Populate();
			// Query - the result appears as a list, which is an object
			// implementing the IEnumerable interface.
			IEnumerable<string> result =
				from x in WordPairList
					where x.English == "nice" &&
										 x.Hungarian.Length < 8
					orderby x.Hungarian
					select x.Hungarian;
			// Display the obtained result on the console.
			Console.Write("nice= ");
			foreach (var s in result)
				Console.Write($"{s}, ");
			Console.ReadLine();
		}

		/// <summary>
		/// Populates the list with some word pairs.
		/// </summary>
		private static void Populate()
		{
			WordPairList.Add(new WordPairs("sun", "nap"));
			WordPairList.Add(new WordPairs("day", "nap"));
			WordPairList.Add(new WordPairs("nice", "kellemes"));
			WordPairList.Add(new WordPairs("nice", "aranyos"));
			WordPairList.Add(new WordPairs("nice", "helyes"));
		}
	}
}
