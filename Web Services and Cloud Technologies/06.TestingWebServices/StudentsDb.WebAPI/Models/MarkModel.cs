using StudentsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentsDb.WebAPI.Models
{
    public class MarkModel
    {
        public int ID { get; set; }

        public string Subject { get; set; }

        public double Value { get; set; }

        public static Expression<Func<Mark, MarkModel>> FromMark
        {
            get
            {
                return x => new MarkModel
                {
                    ID = x.ID,
                    Subject = x.Subject,
                    Value = x.Value
                };
            }
        }

        public static MarkModel CreateModel(Mark model)
        {
            return new MarkModel
            {
                Value = model.Value,
                Subject = model.Subject,
                ID = model.ID
            };
        }

        public Mark CreateMark()
        {
            return new Mark
            {
                ID = this.ID,
                Subject = this.Subject,
                Value = this.Value
            };
        }
    }
}