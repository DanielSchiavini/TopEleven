using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopEleven.TimeCalculator
{
	public static class Program
	{
		internal static void Main(string[] args)
		{
			try
			{
				TimeSpan recoverTime, matchTime, now = DateTime.Now.TimeOfDay;
				if (args.Length >= 1)
				{
					recoverTime = TimeSpan.Parse(args[0]);
				}
				else
				{
					Console.Write("Match start time: ");
					recoverTime = TimeSpan.Parse(Console.ReadLine());
				}

				if (args.Length >= 2)
				{
					matchTime = TimeSpan.Parse(args[1]);
				}
				else
				{
					Console.Write("Match start time: ");
					matchTime = TimeSpan.Parse(Console.ReadLine());
				}

				int result = CalculatePercentage(recoverTime, matchTime, now);
				Console.WriteLine("You should train up to {0}%", result);
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ReadLine();
				Main(args);
			}
		}

		public static int CalculatePercentage(TimeSpan recoverTime, TimeSpan matchTime, TimeSpan now)
		{
			if (recoverTime.TotalHours > 3 || recoverTime.TotalHours < 0)
			{
				throw new ArgumentOutOfRangeException("recoverTime");
			}

			TimeSpan firstRecovery = recoverTime + now;
			TimeSpan totalTime = matchTime - firstRecovery;
			if (totalTime.TotalHours < 0)
			{
				totalTime += TimeSpan.FromDays(1);
			}

			int recoverCount = (int)totalTime.TotalHours / 3;
			return 95 - recoverCount * 5;
		}
	}
}
