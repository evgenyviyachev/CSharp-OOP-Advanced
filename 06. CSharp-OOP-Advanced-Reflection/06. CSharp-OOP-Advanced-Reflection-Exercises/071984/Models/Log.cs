using _071984.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Models
{
    public class Log : ILog
    {
        private string institution;
        private string log = string.Empty;
        private int counter;

        public Log(string institution)
        {
            this.institution = institution;
            this.counter = 0;
        }

        public string Institution
        {
            get
            {
                return this.institution;
            }
            private set
            {
                this.institution = value;
            }
        }

        public void SaveChange(string typeOfEntity, string id, string nameOfField, string typeOfField, string oldValue, string newValue)
        {
            string change = $"--{typeOfEntity}(ID:{id}) changed {nameOfField}({typeOfField}) from {oldValue} to {newValue}\n";
            this.log += change;
            this.counter++;
        }

        public string GetLog()
        {
            string firstLine = $"{this.institution}: {this.counter} changes registered\n";
            this.log = firstLine + this.log;
            return this.log;
        }
    }
}
