using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsDb.WebAPI.Models
{
    public class MarkFullModel : MarkModel
    {
        public StudentModel Student { get; set; }
    }
}