using school.data.Entities;
using school.infrastructuer.Reposatiory.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.infrastructuer.Reposatiory.StudentRepo
{
    public interface IStudentRepositiary : IGenericRepositoryAsync <Student> 
    {
       public Task<List<Student>> GetListStudentAsync();


    }
}
 