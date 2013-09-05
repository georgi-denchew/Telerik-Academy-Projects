using StudentsDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDb.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext() :
            base("StudentsDatabase")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Mark> Marks { get; set; }
    }
}
