using school.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.service.DepartmentService
{
    public interface ISubjectService
    {
        Task<List<Subjects>> GetAllSubjectsAsync();
        Task<Subjects> GetSubjectByIdAsync(int id);
        Task<string> AddSubjectAsync(Subjects subject);
        Task<string> UpdateSubjectAsync(Subjects subject);
        Task<string> DeleteSubjectAsync(int id);
    }
}
