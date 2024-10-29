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
        public void GetSingleStudentMappingQuery()
        {
            CreateMap<Student, GetSingleStudentRespons>()
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
