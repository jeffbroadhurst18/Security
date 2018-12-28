using Security.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Classes
{
	public class ParkrunService : IParkrunService
	{
		private readonly LocationContext _dbContext;

		public ParkrunService(LocationContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> CreateParkrun(Parkrun parkrun)
		{
			_dbContext.Add(parkrun);
			await _dbContext.SaveChangesAsync();
			return parkrun.Id;
		}

		public List<Parkrun> GetAllParkruns()
		{
			return _dbContext.Parkruns.OrderBy(o => o.RaceDate).ToList();
		}

		public List<Parkrun> GetParkrunsByYear(int year)
		{
			var start = new DateTime(year, 1, 1);
			var end = new DateTime(year, 12, 31);
			return _dbContext.Parkruns.Where(y => y.RaceDate >= start && y.RaceDate <= end).OrderBy(o => o.RaceDate).ToList();
		}

		public Parkrun GetParkunById(int id)
		{
			return _dbContext.Parkruns.First(p => p.Id == id);
		}
	}
}
