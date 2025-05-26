using school.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.service.DepartmentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<string> AddStudentAsync(Student student);
        Task<string> UpdateStudentAsync(Student student);
        Task<string> DeleteStudentAsync(int id);
        Task<bool> IsNameExist(string name);
    }
}
