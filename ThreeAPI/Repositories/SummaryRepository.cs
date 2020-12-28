using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Models;
using ThreeAPI.Services;

namespace ThreeAPI.Repositories
{
	public class SummaryRepository : ISummaryRepository
	{
		private readonly IDepartmentRepository _departmentRepository;
		public SummaryRepository(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		public Task<CompanySummary> GetCompanySummary()
		{
			return Task.Run(() =>
			{
				var all = _departmentRepository.GetAll().Result;
				return new CompanySummary
				{
					EmployeeCount = all.Sum(x => x.EmployeeCount),
					AverageDepartmentEmployeeCount = (int)all.Average(x => x.EmployeeCount)
			};
			});
		}
	}
}
