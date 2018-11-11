using System.Threading.Tasks;
using Security.Data;

namespace Security.Classes
{
	public interface IUserService
	{
		string Authenticate(ApplicationUser user);
		Task<ApplicationUser> GetUser(string username, string password);
	}
}