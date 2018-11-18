using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Data
{
	public class Parkrun
	{
		public int Id { get; set; }

		public DateTime RaceDate { get; set; }

		public int Race { get; set; }

		public int Position { get; set; }

		public string Grade { get; set; }

		public int Minutes { get; set; }

		public int Seconds { get; set; }
	}
}
