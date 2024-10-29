using Microsoft.EntityFrameworkCore;
using school.data.Entities;
using school.infrastructuer.Reposatiory.StudentRepo;

namespace school.service.StudentServicerepo
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositiary _studentRepositiary;

        public StudentService(IStudentRepositiary studentRepositiary)
        {
            _studentRepositiary = studentRepositiary;
        }



        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _studentRepositiary.GetListStudentAsync();
        }


        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var studentById = _studentRepositiary.GetTableNoTracking()
                .Include(d => d.Department).Where(d => d.StudID.Equals(id))
                .FirstOrDefault();
            return studentById;
        }

        public async Task<string> AddStudentAsync(Student student)
        {

            await _studentRepositiary.AddAsync(student);
            return "Success";

        }

        public async Task<bool> IsNameExist(string name)
        {
            //chek the name is Exist or not
            var studentName = _studentRepositiary.GetTableNoTracking().Where(n => n.Name.Equals(name)).FirstOrDefault();
            if (studentName == null) return false;
            return true;
        }



        public async Task<bool> IsNameExistExcloudSelf(string name, int id)
        {
            //chek the name is Exist or not
            var studentName = _studentRepositiary.GetTableNoTracking().Where(n => n.Name.Equals(name) & !n.StudID.Equals(id)).FirstOrDefaultAsync();
            if (studentName == null) return false;
            return true;
        }
    }
}
