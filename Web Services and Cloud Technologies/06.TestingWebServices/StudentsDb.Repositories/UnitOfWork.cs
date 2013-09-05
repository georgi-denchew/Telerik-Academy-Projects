using StudentsDb.Data;
using StudentsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDb.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private StudentsDbContext context = new StudentsDbContext();
        private EfRepository<Student> studentRepository;
        private EfRepository<School> schoolsRepository;
        private EfRepository<Mark> marksRepository;
        private bool disposed;

        public EfRepository<Student> StudentsRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new EfRepository<Student>(context);
                }

                return this.studentRepository;
            }
        }

        public EfRepository<School> SchoolsRepository
        {
            get
            {
                if (this.schoolsRepository == null)
                {
                    this.schoolsRepository = new EfRepository<School>(context);
                }

                return this.schoolsRepository;
            }
        }

        public EfRepository<Mark> MarksRepository
        {
            get
            {
                if (this.marksRepository == null)
                {
                    this.marksRepository = new EfRepository<Mark>(context);
                }

                return this.marksRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
