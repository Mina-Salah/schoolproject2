using school.data.Entities;

namespace school.service.StudentServicerepo
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIdAsync(int id);

        public Task<string> AddStudentAsync(Student student);

        public Task<bool> IsNameExist(string name);

        public Task<bool> IsNameExistExcloudSelf(string name, int id);

    }
}
