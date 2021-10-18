using System;
using System.Collections.Generic;
using System.Linq;

namespace mutualFriends
{
	public class Program
	{


		public static void Main(string[] args)
		{
			//lists to hold friends lists for users 1 and 2
			List<string> user1friends = new List<string>();
			List<string> user2friends = new List<string>();


			string friends1 = "";
			string friends2 = "";

			Console.WriteLine("Please enter the list of friends for user 1. When finished, type DONE");
			//while loop for adding user 1 friends
			while (friends1 != "DONE")
			{
				friends1 = Console.ReadLine();
				user1friends.Add(friends1);
			}
			//removes DONE from list
			user1friends.Remove("DONE");

			Console.WriteLine("Please enter the list of friends for user 2. When finished, type DONE");
			//while loop for adding user 2 friends
			while (friends2 != "DONE")
			{
				friends2 = Console.ReadLine();
				user2friends.Add(friends2);
			}
			//removes DONE from list
			user2friends.Remove("DONE");

			//finds the intersection of the two lists and outputs a list of mutual friends
			IEnumerable<string> mutual = user1friends.AsQueryable().Intersect(user2friends);

			//check if no freinds in list
			if (!mutual.Any())
			{
				Console.WriteLine("No friends in common.");
			}

			else
			{
				Console.WriteLine("The Friends that both users have in common are as follows:");
				foreach (string a in mutual)
				{
					Console.WriteLine(a);
				}
			}
			
			//recommended friends list
			IEnumerable<string> recommendedFriends1 = user2friends.AsQueryable().Except(user1friends);

			//check if no freinds in recommendedFriends1
			if (!recommendedFriends1.Any())
			{
				Console.WriteLine("No recommendations.");
			}

			else
			{
				Console.WriteLine("The recommended friends for user 1:");
				foreach (string b in recommendedFriends1)
				{
					Console.WriteLine(b);
				}
			}


			//recommended friends in recommendedFriends2
			IEnumerable<string> recommendedFriends2 = user1friends.AsQueryable().Except(user2friends);

			if (!recommendedFriends2.Any())
			{
				Console.WriteLine("No recommendations.");
			}

			else
			{
				Console.WriteLine("The recommended friends for user 2:");
				foreach (string b in recommendedFriends2)
				{
					Console.WriteLine(b);
				}
			}
		}
	}
}
