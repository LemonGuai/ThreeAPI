using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Models;

namespace ThreeAPI.Repositories
{
	public interface ISummaryRepository
	{
		Task<CompanySummary> GetCompanySummary();


	}
}
