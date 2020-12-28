﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Models;

namespace ThreeAPI.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();
        public EmployeeRepository()//添加员工
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "Nick",
                LastName = "Carter",
                Gender = Gender.male
            });
            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "Michael",
                LastName = "Jackson",
                Gender = Gender.male
            });
            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 1,
                FirstName = "Mariah",
                LastName = "Carey",
                Gender = Gender.female
            });
            _employees.Add(new Employee
            {
                Id = 5,
                DepartmentId = 2,
                FirstName = "Kate",
                LastName = "Winslet",
                Gender = Gender.female
            });
            _employees.Add(new Employee
            {
                Id = 6,
                DepartmentId = 2,
                FirstName = "Rob",
                LastName = "Thomas",
                Gender = Gender.male
            });
            _employees.Add(new Employee
            {
                Id = 7,
                DepartmentId = 3,
                FirstName = "Avril",
                LastName = "Lavigne",
                Gender = Gender.female
            });
            _employees.Add(new Employee
            {
                Id = 8,
                DepartmentId = 3,
                FirstName = "Katy",
                LastName = "Perry",
                Gender = Gender.female
            });
            _employees.Add(new Employee
            {
                Id = 9,
                DepartmentId = 3,
                FirstName = "Michelle",
                LastName = "Monaghan",
                Gender = Gender.female
            });
        }

        public Task Add(Employee employee)//添加员工
        {
            employee.Id = _employees.Max(x => x.Id)+1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int id)//开除员工
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(e => e.Id == id);//通过ID找到员工
                if (employee != null)//如果员工存在则把Fired属性改为true
                {
                    employee.Fired = true;
                    return employee;
                }

                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetById(int departmentId)//根据部门id获取对应部门的所有员工
        {
            return Task.Run(() => _employees.Where(x => x.DepartmentId == departmentId));
        }
    }
}
