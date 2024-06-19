namespace Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        public void Add(T entity);
        public void Update(T entity, T updateEntity);
        public IEnumerable<T> GetAll();
        public bool Any(Func<T, bool> predicate);
        public T? GetByCondition(Func<T, bool> predicate);
        public void Save();
        public void Delete(T entity);
    }

}
