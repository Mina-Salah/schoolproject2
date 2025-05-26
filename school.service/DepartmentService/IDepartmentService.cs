using school.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.service.DepartmentService
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<string> AddDepartmentAsync(Department department);
        Task<string> UpdateDepartmentAsync(Department department);
        Task<string> DeleteDepartmentAsync(int id);
    }
}
