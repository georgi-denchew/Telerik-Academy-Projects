using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Nullable<DateTime> JoinDate { get; set; }

        public string AvatarPath { get; set; }

        public ApplicationUser(string userName)
            : base(userName)
        {
            this.Courses = new HashSet<Course>();
        }

        public ApplicationUser()
            : base()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }


        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }

    public class AcademyDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public AcademyDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Courses)
                .WithRequired(c => c.Lecturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Courses)
                .WithMany(a => a.Students)
                .Map(t =>
                    {
                        t.ToTable("UsersCourses");
                        t.MapLeftKey("UserId");
                        t.MapRightKey("CourseId");
                    });
        }
    }
}