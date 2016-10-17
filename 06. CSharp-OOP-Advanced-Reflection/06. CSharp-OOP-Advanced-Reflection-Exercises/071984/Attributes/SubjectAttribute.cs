using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SubjectAttribute : Attribute
    {
        private string name;

        public SubjectAttribute(string name)
        {
            this.name = name;
        }
    }
}
