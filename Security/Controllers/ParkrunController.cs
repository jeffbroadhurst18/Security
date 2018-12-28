﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security.Classes;
using Security.Data;

namespace Security.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[Produces("application/json")]
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
		[HttpGet("{id}",Name = nameof(GetById))]
		public IActionResult GetById(int id)
		{
			var parkrun = _parkrunService.GetParkunById(id);
			return Ok(parkrun);
		}

		[EnableCors("AnyGET")]
		[HttpGet("year/{year}", Name = "Get")]
		public IActionResult Get(int year)
		{
			var parkruns = _parkrunService.GetParkrunsByYear(year);
			return Ok(parkruns);
		}

        // POST: api/Parkrun
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
			var parkrun = JsonConvert.DeserializeObject<Parkrun>(value);
			var id = await _parkrunService.CreateParkrun(parkrun);
			return CreatedAtRoute("api/[controller]", new { id = id }, parkrun);
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
