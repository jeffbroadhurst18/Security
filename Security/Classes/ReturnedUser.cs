using Security.Data;

namespace Security.Classes
{
	public class ReturnedUser
	{
		public ApplicationUser User { get; set; }
		public string token { get; set; }
	}
}
