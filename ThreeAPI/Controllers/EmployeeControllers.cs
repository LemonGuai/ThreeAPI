using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Models;
using ThreeAPI.Repositories;

namespace ThreeAPI.Controllers
{
	[Route("v1/[Controller]")] //指定全类的对应路由路径 v1/department
	[ApiController]
	public class EmployeeControllers:ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeControllers(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[HttpGet("departmentId")] //在全类的对应路由路径 v1/department 加上departmentId
		public async Task<IActionResult> GetByDepartmentId(int departmentId)
		{
			var employees = await _employeeRepository.GetById(departmentId);
			if (!employees.Any())
			{
				return NoContent();//绝对不应返回NotFound()
			}
			return Ok(employees);
		}
		/*
		 1."one"是为了跟GetByDepartmentId的路由配置区分开来
		 2.给这个action起了个名字:GetById
		 3. Ok()方法返回的状态码是200
		 */
		[HttpGet("one/id",Name = "GetById")] 
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _employeeRepository.GetById(id);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody]Employee model)
		{
			var added = await _employeeRepository.Add(model);
			/*
			 1.未来想获取CreatedAtRoute的方法是通过GetById这个action来获取的 
			 2.GetById(int id)需要一个参数,通过匿名类 new { id = added.Id }传入
			 3. 第三个参数来返回 Add()本方法的数据,前台走完这个方法之后就能获取到添加的added资源了
			 4. CreatedAtRoute()返回的状态为201
			*/
			return CreatedAtRoute("GetById", new { id = added.Id }, added);
		}
		[HttpPut("{id}")]//Put这个动作表示对资源进行整体(所有字段)的更新,使用Patch可能更好
		public async Task<IActionResult> Fire(int id)
		{
			var result = await _employeeRepository.Fire(id);
			if (result != null)
			{
				return NoContent();
			}
			return NotFound();
		}
	}
}
