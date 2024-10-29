using Microsoft.Extensions.DependencyInjection;
using school.infrastructuer.Reposatiory.StudentEntity;
using school.infrastructuer.Reposatiory.StudentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace school.infrastructuer
{
    public static class ModuleinfrastructuerDependency
    {
        public static IServiceCollection addInfrastrustuerdependecies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepositiary, StudentRepositiry>();
            return services;
        }
    }
}
