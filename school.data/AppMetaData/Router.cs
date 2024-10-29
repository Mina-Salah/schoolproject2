using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.data.AppMetaData
{
    public static class Router
    {
        public const string Root = "API";
        public const string Version = "VI";
        public const string Rule = Root + "/" + Version + "/";



        public static class StudentRouting
        {
            public const string StudentRoot = Rule + "students";

            // Example routes for students
            public const string GetAllStudents = StudentRoot + "/all";
            public const string GetStudentById = StudentRoot + "/{id}";
            public const string AddStudent = StudentRoot + "/add";
            public const string UpdateStudent = StudentRoot + "/update/{id}";
            public const string DeleteStudent = StudentRoot + "/delete/{id}";
        }
    }
}
