using System.Collections.Generic;

namespace Blog.BussinesLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T : class
    {
        void Add(T t);
        void Update(T t);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Save();
    }
}
