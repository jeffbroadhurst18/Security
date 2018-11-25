using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Classes;
using Security.Data;

namespace Security.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ParkrunController : ControllerBase
    {
		private readonly IParkrunService _parkrunService;

		public ParkrunController(IParkrunService parkrunService)
		{
			_parkrunService = parkrunService;
		}

		// GET: api/Parkrun
		[EnableCors("AnyGET")]
		[HttpGet]
        public IActionResult Get()
        {
			var parkruns = _parkrunService.GetAllParkruns();
			return Ok(parkruns);
        }

		[EnableCors("AnyGET")]
		[Route("year/{year}")]
		[HttpGet("{year}", Name = "Get")]
		public IActionResult Get(int year)
		{
			var parkruns = _parkrunService.GetParkrunsByYear(year);
			return Ok(parkruns);
		}

		//// GET: api/Parkrun/5
		//[HttpGet("{id}", Name = "Get")]
  //      public string Get(int id)
  //      {
  //          return "value";
  //      }

        // POST: api/Parkrun
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Parkrun/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
