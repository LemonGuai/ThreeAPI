using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Models;

namespace ThreeAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> Add(Employee employee);//添加员工
        Task<IEnumerable<Employee>> GetById(int departmentId);//按照部门Id获取指定部门的所有员工
        Task<Employee> Fire(int id);//按照员工ID开除员工
    }
}
