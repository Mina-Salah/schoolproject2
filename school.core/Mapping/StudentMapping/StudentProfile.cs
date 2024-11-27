using AutoMapper;
using school.core.Futuer.Students.Queries.ResultRespons;
using school.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // Mapping Student to GetListStudentResponse, including DepartmentName
            GetStudentListMapping();
            GetSingleStudentMappingQuery();
            AddStudentCommendMapping();
            UpdateStudentCommendMapping();
        }
    }

}
