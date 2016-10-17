using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Contracts
{
    public interface IInstitution
    {
        string Name { get; }
        IList<string> FieldsToWatch { get; }
        void RegisterChange(string typeOfEntity, string id, string nameOfField, string typeOfField, string oldValue, string newValue);
        void PrintInstitution();
    }
}
