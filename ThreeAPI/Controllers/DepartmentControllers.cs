using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Models;
using ThreeAPI.Repositories;

namespace ThreeAPI.Controllers
{
	/*
	 1.使用 route特性的原因在于StartUp.Configure中
	 2.没有为路由中的[controller]指定action的原因是:Restful API主要是通过 动词 来区分action
	 3.指定全类的对应路由路径 v1/department
	 */
	[Microsoft.AspNetCore.Components.Route(template: "v1/[controller]")] 

	[ApiController]

	/*
	 1. API Controller推荐继承ControllerBase,因为Controller里面有对view的支持
	 2. MVC Controller中继承的是Controller, Controller继承了ControllerBase,区别是Controller里面有对view的支持
	 3. API不需要view
	*/
	public class DepartmentControllers:ControllerBase 
	{
		private readonly IDepartmentRepository _departmentRepository;
		public DepartmentControllers(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		[HttpGet]  //对应的路由路径 v1/department  动词:Get
		public async Task<ActionResult<IEnumerable<Department>>> GetAll() //或者使用Task<IActionResult>
		{
			var departments = await _departmentRepository.GetAll();
			if (!departments.Any())//如果什么都没有
			{
				return NoContent();
			}

			//有记录 //对应的路由路径 v1/department  动词:Post
			return Ok(departments);
			//return new ObjectResult(departments);
		}

		[HttpPost]
		public async Task<ActionResult<Department>> Add([FromBody]Department department)//参数是从body里面来的
		{
			var added = await _departmentRepository.Add(department);
			return Ok(added);
		}
	}
}
