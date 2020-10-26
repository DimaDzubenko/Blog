using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.DataLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        protected ApplicationDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public GenericRepository(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            _context = new ApplicationDbContext(optionsBuilder.Options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public virtual void Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual T Update(T t)
        {
            if (t == null)
                return null;
            T exist = _context.Set<T>().Find(t);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                _context.SaveChanges();
            }
            return exist;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
