﻿using school.data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school.service.StudentServicerepo
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentListAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<string> AddStudentAsync(Student student);
        Task<string> UpdateAsync(Student student);
        Task DeleteStudentAsync(int id); 
        Task<bool> IsNameExist(string name);
        Task<bool> IsNameExistExcloudSelf(string name, int id);
    }
}
