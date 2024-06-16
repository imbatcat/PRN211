using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly HospitalAppDbContext context;
        private readonly DbSet<T> dbSet;

        public RepositoryBase()
        {
            context = new HospitalAppDbContext();
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            Save();
        }

        public bool Any(Func<T, bool> predicate)
        {
            return dbSet.Any(predicate);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            Save();
        }

        public IEnumerable<T> GetAll(T entity)
        {
            return dbSet.ToList();

        }

        public T? GetByCondition(Func<T, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity, T updateEntity)
        {
            context.Entry(entity).CurrentValues.SetValues(updateEntity);
            Save();
        }
    }
}
