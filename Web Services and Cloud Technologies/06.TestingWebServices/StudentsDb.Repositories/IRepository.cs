using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDb.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T item);
        IQueryable<T> All();
        T Get(int ID);
        T Update(int ID, T item);
        void Delete(int ID);

        void Delete(T item);
    }
}
