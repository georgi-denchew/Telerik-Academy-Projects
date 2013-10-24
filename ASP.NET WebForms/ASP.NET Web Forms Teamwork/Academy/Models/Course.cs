using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public ICollection<ApplicationUser> Students { get; set; }

        public virtual ApplicationUser Lecturer { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }

        public int FreePlaces { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsClosed { get; set; }

        public Course()
        {
            this.Students = new HashSet<ApplicationUser>();
            this.Lectures = new HashSet<Lecture>();
        }
    }
}