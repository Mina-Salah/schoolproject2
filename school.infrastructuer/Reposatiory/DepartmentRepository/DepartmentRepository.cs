using Microsoft.EntityFrameworkCore;
using school.data.Entities;
using school.infrastructuer.DateContext;
using school.infrastructuer.Reposatiory.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.infrastructuer.Reposatiory.DepartmentRepository
{
    public class DepartmentRepository:GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private readonly DbSet<Department> _students;
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Department>();
        }
    }
}
