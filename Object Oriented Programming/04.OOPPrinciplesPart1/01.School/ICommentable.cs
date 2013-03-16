using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public interface ICommentable
    {
        string Comments { get;}
         void AddComment(string comment);
    }
}
