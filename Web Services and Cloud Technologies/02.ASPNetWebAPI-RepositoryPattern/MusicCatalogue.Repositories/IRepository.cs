using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.Repositories
{
    interface IRepository<T> where T : class
    {
        void Add(T item);
        IQueryable<T> All();
        T Get(int ID);
        void Update(int ID, T item);
        void Delete(int ID);
    }
}
