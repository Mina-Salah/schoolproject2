using Microsoft.EntityFrameworkCore;
using school.data.Entities;
using school.infrastructuer.DateContext;
using school.infrastructuer.Reposatiory.GenericRepository;
using school.infrastructuer.Reposatiory.StudentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.infrastructuer.Reposatiory.StudentEntity
{
    public class StudentRepositiry :GenericRepositoryAsync<Student> , IStudentRepositiary
    {
        private readonly DbSet<Student>_students; 
        public StudentRepositiry(ApplicationDbContext dbContext):base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }
        public async Task<List<Student>> GetListStudentAsync()
        {
            return await _students.Include(s => s.Department) // Eager load the Department entity
                                   .ToListAsync();
        }

     
    }
}
