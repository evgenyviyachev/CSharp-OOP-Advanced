using _071984.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Models
{
    public class Institution : IInstitution
    {
        private string name;
        private IList<string> fieldsToWatch;
        private readonly string id;
        private Log log;

        public Institution(string name, string id, IList<string> fieldsToWatch)
        {
            this.Name = name;
            this.id = id;
            this.FieldsToWatch = fieldsToWatch;
            this.log = new Log(this.Name);
        }

        public IList<string> FieldsToWatch
        {
            get
            {
                return this.fieldsToWatch;
            }
            private set
            {
                if (value == null)
                {
                    this.fieldsToWatch = new List<string>();
                }
                else
                {
                    this.fieldsToWatch = value;
                }                
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public void RegisterChange(string typeOfEntity, string id, string nameOfField, string typeOfField, string oldValue, string newValue)
        {
            this.log.SaveChange(typeOfEntity, id, nameOfField, typeOfField, oldValue, newValue);
        }

        public void PrintInstitution()
        {
            Console.Write(this.log.GetLog());
        }
    }
}
