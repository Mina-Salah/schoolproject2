using Microsoft.Extensions.DependencyInjection;
using school.infrastructuer.Reposatiory.StudentEntity;
using school.service.StudentServicerepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace school.service
{
    public static class ModuleServiceDependency
    {
        public static IServiceCollection addSevicesdependecies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            return services;
        }
    }
}
