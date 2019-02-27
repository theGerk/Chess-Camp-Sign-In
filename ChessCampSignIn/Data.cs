using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ChessCampSignIn
{
	public struct Submission
	{
		public Submission(string camperName, string morningActivity, string afternoonActivity)
		{
			Timestamp = DateTime.Now;
			CamperName = camperName;
			Morning = morningActivity;
			Afternoon = afternoonActivity;
		}

		public DateTime Timestamp { get; set; }
		public string CamperName { get; set; }
		public string Morning { get; set; }
		public string Afternoon { get; set; }
	}

	public struct Camper
	{
		public string Name { get; }
		public SimmingAbility SwimAbility { get; }
		public bool AM { get; }
		public bool PM { get; }
	}

	public enum SimmingAbility
	{
		NoSwimming,
		ShalowAndSlide,
		Confident
	}

	public class Week : IEquatable<Week>, ICloneable
	{
		public const string SignInDataFolder = "Camp_SignIn_Folder\\";

		public static Week Current = null;

		public IEnumerable<Camper> Campers { get; }
		public uint WeekNumber { get; }
		public uint Year { get; }
		private string directory;
		
		private static string GetDirectory(uint weekNumber, uint year)
		{
			return $"{SignInDataFolder}Week_{weekNumber}-{year}\\";
		}

		private const string CamperDataFile = "Campers.dat";
		private const string SubmissionsFile = "Submissions.dat";

		public static bool WeekExists(uint weekNumber, uint year)
		{
			return Directory.Exists(GetDirectory(weekNumber, year));
		}

		//put on pause, will come back to
		public Week(uint number, uint year)
		{
			WeekNumber = number;
			Year = year;

			//find camper week
			directory = GetDirectory(number, year);

			try {
				Campers = File.ReadAllLines(GetDirectory(number, year) + CamperDataFile).Select(JsonConvert.DeserializeObject<Camper>);
			} catch (DirectoryNotFoundException) {
				if (!Directory.Exists(SignInDataFolder)) {
					Directory.CreateDirectory(SignInDataFolder);
				}
				Directory.CreateDirectory(GetDirectory(number, year));
				throw new FileNotFoundException("This must be a new week, must create data for this week or throw it away and create a new one");
			}
		}

		public bool Equals(Week other)
		{
			return WeekNumber == other.WeekNumber && Year == other.Year;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}

	/// <summary>
	/// Holds morning and afternoon activity options
	/// </summary>
	public struct Activities : IEquatable<Activities>, ICloneable
	{
		public const string ActivitiesFile = "Activities.dat";
		public string[] Morning { get; }
		public string[] Afternoon { get; }

		public Activities(IEnumerable<string> morning, IEnumerable<string> afternoon)
		{
			Morning = morning.ToArray();
			Afternoon = afternoon.ToArray();
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="original">original to be copied</param>
		public Activities(Activities original)
		{
			Morning = new string[original.Morning.Length];
			Afternoon = new string[original.Afternoon.Length];

			Array.Copy(original.Morning, Morning, Morning.Length);
			Array.Copy(original.Afternoon, Afternoon, Afternoon.Length);
		}

		/// <summary>
		/// Create activity object from file refrenced by <see cref="ActivitiesFile"/>
		/// </summary>
		/// <returns>Activites</returns>
		private static Activities Read()
		{
			var str = File.ReadAllLines(ActivitiesFile);
			switch (str.Length) {
				case 1:
					return new Activities(str[0].Split('\t').Select(s => s.Trim()).Where(s => s != ""), new string[0]);
				case 2:
					return new Activities(str[0].Split('\t').Select(s => s.Trim()).Where(s => s != ""), str[1].Split('\t').Select(s => s.Trim()).Where(s => s != ""));
				default:
					return new Activities(new string[0], new string[0]);
			}
		}

		private static void Write(Activities act)
		{
			File.WriteAllLines(ActivitiesFile, new string[] {
				act.Morning.Aggregate((a, b) => a + '\t' + b),
				act.Afternoon.Aggregate((a, b) => a + '\t' + b)
			});
		}

		public bool Equals(Activities other)
		{
			return Morning.SequenceEqual(other.Morning) && Afternoon.SequenceEqual(other.Afternoon);
		}

		object ICloneable.Clone()
		{
			return new Activities(this);
		}

		private static Activities current = Read();


		public static Activities Current {
			get
			{
				return current;
			}
			set
			{
				if(!current.Equals(value)) {
					current = new Activities(value);
					Write(value);
				}
			}
		}
	}
}
