using school.core.Futuer.Students.commends.Module;
using school.core.Futuer.Students.Queries.ResultRespons;
using school.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddStudentCommendMapping()
        {
            CreateMap<AddStudentCommend,Student>()
               .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
