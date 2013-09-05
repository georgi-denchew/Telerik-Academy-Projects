using StudentsDb.Models;
using StudentsDb.Repositories;
using StudentsDb.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;


namespace StudentsDb.IntegrationTests
{

    class TestPlacesDependencyResolver<T> : IDependencyResolver  where T : class
    {
        private IRepository<T> repository;

        public IRepository<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.repository as IRepository<Student>);
            }
            else if (serviceType == typeof(StudentsController))
            {
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}
