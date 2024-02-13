using CI.BRE.REPOSITERY.ApplicationDbContext;
using CI.BRE.REPOSITERY.Entities;
using CI.BRE.SERVICE.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CI.BRE.SERVICE.Service
{
    public class Service<T> : IService<T> where T : class
    {

        private readonly breprojectContext _breprojectContext;
        private readonly DbSet<T> _dbSet;
        public Service(breprojectContext breprojectContext)
        {
            try
            {
                _breprojectContext = breprojectContext;
                _dbSet = breprojectContext.Set<T>();
            }
            catch(Exception ex)
            {
               
            }
           
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var data = await _dbSet.ToListAsync();
                return data;
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }
    

        public async Task<T> GetByIdAsync(int id)
        {
                return await _dbSet.FindAsync(id);
        }

        public async Task PutAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _breprojectContext.Entry(entity).State = EntityState.Modified;
                await _breprojectContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                
            }
       
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                await _breprojectContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
           
        }

    }
}
