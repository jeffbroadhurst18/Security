using Security.Data;
using System.Collections.Generic;

namespace Security.Classes
{
	public interface IParkrunService
	{
		List<Parkrun> GetAllParkruns();
		List<Parkrun> GetParkrunsByYear(int year);
	}
}