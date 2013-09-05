using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        public EfRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("The DbContext variable passed to the repository cannot be null");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        public DbContext Context { get; set; }
        public IDbSet<T> DbSet { get; set; }

        public void Add(T item)
        {
            this.DbSet.Add(item);

            this.Context.SaveChanges();
        }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public T Get(int ID)
        {
            var result =  this.DbSet.Find(ID);
            this.DbSet.Attach(result);
            return result;
        }

        public void Update(int ID, T item)
        {
            T entity = this.DbSet.Find(ID);

            if (entity != null)
            {
                this.Context.Entry(entity).CurrentValues.SetValues(item);
            }
            else
            {
                this.Add(item);
            }

            this.Context.SaveChanges();
        }

        public void Delete(int ID)
        {
            T entity = this.Get(ID);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Delete(T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);

            if (entry.State != System.Data.EntityState.Deleted)
            {
                entry.State = System.Data.EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(item);
                this.DbSet.Remove(item);
            }

            this.Context.SaveChanges();
        }
    }
}
