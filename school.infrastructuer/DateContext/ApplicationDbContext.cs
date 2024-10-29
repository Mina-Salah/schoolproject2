
using Microsoft.EntityFrameworkCore;
using school.data.Entities;

namespace school.infrastructuer.DateContext
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }


        public DbSet<Student> Students { get; set; }    
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Department> Departments { get; set; }  
        public DbSet<DepartmetSubject> departmetSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
    }
}
