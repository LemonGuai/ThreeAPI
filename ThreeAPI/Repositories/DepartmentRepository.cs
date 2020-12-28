using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Models;

namespace ThreeAPI.Repositories
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly List<Department> _departments = new List<Department>();

		public DepartmentRepository()//添加3个部门
		{
			_departments.Add(new Department
			{
				Id = 1,
				Name = "HR",
				EmployeeCount = 16,
				Location = "Beijing"
			});
			_departments.Add(new Department
			{
				Id = 2,
				Name = "RD",
				EmployeeCount = 52,
				Location = "Shanghai"
			});
			_departments.Add(new Department
			{
				Id = 3,
				Name = "Sales",
				EmployeeCount = 200,
				Location = "China"
			});
		}
		public Task<IEnumerable<Department>> GetAll()
		{
			return Task.Run(() => _departments.AsEnumerable());
		}

		public Task<Department> GetById(int id)
		{
			return Task.Run(() => _departments.FirstOrDefault(x => x.Id == id));//根据id查记录
		}


		public Task<Department> Add(Department department)
		{
			department.Id = _departments.Max(x => x.Id) + 1;//设置ID:现有部门中最大的ID+1 = 添加的记录ID
			_departments.Add(department);
			return Task.Run(() => department);
		}


	}
}
