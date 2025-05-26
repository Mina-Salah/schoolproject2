using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.infrastructuer.Reposatiory.GenericRepository
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);//used
        Task SaveChangesAsync();//used
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);//used
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);//used
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);//used
    }
}
