using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilRouge.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public T Get(int id);
        public List<T> GetAll();
        public T Search(Expression<Func<T, bool>> searchMethod);
        public List<T> SearchAll(Expression<Func<T, bool>> searchMethod);
        public bool Add(T entity);
        public bool Delete(int id);
        public bool Update(int id, T entity);
    }
}