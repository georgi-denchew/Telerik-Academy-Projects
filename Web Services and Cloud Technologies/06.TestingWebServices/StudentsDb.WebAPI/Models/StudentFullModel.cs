using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StudentsDb.WebAPI.Models
{
    [DataContract]
    public class StudentFullModel : StudentModel
    {
        public StudentFullModel()
        {
            this.Marks = new HashSet<MarkModel>();
        }

        [DataMember(Name="school")]
        public SchoolModel School { get; set; }

        [DataMember(Name="marks")]
        public IEnumerable<MarkModel> Marks { get; set; }
    }
}