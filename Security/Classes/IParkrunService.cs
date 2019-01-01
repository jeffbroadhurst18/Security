using Security.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Security.Classes
{
	public interface IParkrunService
	{
		List<Parkrun> GetAllParkruns();
		List<Parkrun> GetParkrunsByYear(int year);
		Task<int> CreateParkrun(Parkrun parkrun);
		Parkrun GetParkunById(int id);
		Task<int> UpdateParkrun(Parkrun parkrun);
		Task DeleteParkrun(int id);
	}
}