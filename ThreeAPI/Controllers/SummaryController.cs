using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Repositories;

namespace ThreeAPI.Controllers
{
	[Microsoft.AspNetCore.Components.Route("v1/[controller]")]
	[ApiController]
	public class SummaryController:ControllerBase
	{
		private readonly ISummaryRepository _summaryRepository;

		public SummaryController(ISummaryRepository summaryRepository)
		{
			_summaryRepository = summaryRepository;
		}

		public async Task<IActionResult> Get()
		{
			var result = _summaryRepository.GetCompanySummary();
			return Ok(result);
		}

		//看到15:00 准备看ApiController Attribute
	}
}
