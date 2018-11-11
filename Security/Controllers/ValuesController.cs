using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Classes;
using Security.Data;

namespace Security.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly LocationContext _context;

		public ValuesController(LocationContext context)
		{
			_context = context;
		}

		// GET api/values
		[HttpGet]
		public IActionResult Get()
		{
			var locations = _context.Locations.OrderBy(c => c.City).ToList();
			if (locations.Count == 0)
			{
				return BadRequest("No rows returned");
			}
			return Ok(locations);
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
