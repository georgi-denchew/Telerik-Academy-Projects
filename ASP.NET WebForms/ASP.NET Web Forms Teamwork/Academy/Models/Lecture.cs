using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Lecture
    {
        public Lecture()
        {
            this.Homeworks = new HashSet<Homework>();
            this.Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual Course Course { get; set; }

        public string Location { get; set; }

        public DateTime HomeworkDueDate { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}