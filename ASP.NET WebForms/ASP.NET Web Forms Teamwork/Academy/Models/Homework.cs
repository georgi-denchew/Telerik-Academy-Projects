using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Homework
    {
        [Key]
        [Column(Order = 0)]
        public string StudentId { get; set; }

        public ApplicationUser Student { get; set; }

        [Key]
        [Column(Order = 1)]
        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }

        public string HomeworkPath { get; set; }

        public DateTime SubmissionTime { get; set; }
    }
}