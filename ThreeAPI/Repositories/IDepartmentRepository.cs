using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Models;

namespace ThreeAPI.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();//获取所有的部门
        Task<Department> GetById(int id);//通过ID获取部门
        Task<Department> Add(Department model);//添加部门
    }
}
