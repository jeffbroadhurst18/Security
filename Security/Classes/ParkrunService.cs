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

		public List<Parkrun> GetAllParkruns()
		{
			return _dbContext.Parkruns.OrderBy(o => o.RaceDate).ToList();
		}
	}
}
