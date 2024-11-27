using Microsoft.EntityFrameworkCore;
using school.data.Entities;
using school.infrastructuer.Reposatiory.StudentRepo;
using school.infrastructuer.Reposatiory.StudentEntity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace school.service.StudentServicerepo
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositiary _studentRepository;

        public StudentService(IStudentRepositiary studentRepositiary)
        {
            _studentRepository = studentRepositiary;
        }

        // Get all students
        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _studentRepository.GetListStudentAsync();
        }

        // Get a student by ID
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var studentById = _studentRepository.GetTableNoTracking()
                .Include(d => d.Department)  // Including department details if necessary
                .Where(d => d.StudID.Equals(id))
                .FirstOrDefault();
            return studentById;
        }

        // Add a new student
        public async Task<string> AddStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        // Check if student name exists
        public async Task<bool> IsNameExist(string name)
        {
            var studentName = _studentRepository.GetTableNoTracking().Where(n => n.Name.Equals(name)).FirstOrDefault();
            return studentName != null;
        }

        // Check if student name exists, excluding the current student by ID
        public async Task<bool> IsNameExistExcloudSelf(string name, int id)
        {
            var studentName = await _studentRepository.GetTableNoTracking().Where(n => n.Name.Equals(name) && !n.StudID.Equals(id)).FirstOrDefaultAsync();
            return studentName != null;
        }

        // Update a student
        public async Task<string> UpdateAsync(Student student)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(student.StudID);
            if (existingStudent == null)
            {
                return "Student not found";  // Return if student doesn't exist
            }

            // Update the student entity
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        // Delete a student
        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student != null)
            {
                await _studentRepository.DeleteAsync(student);
            }
        }
    }
}
