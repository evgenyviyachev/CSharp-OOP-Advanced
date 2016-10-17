using _071984.Attributes;
using _071984.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Models
{
    public class Employee : ISubject
    {
        [Subject("name")]
        private string name;
        [Subject("income")]
        private int income;
        private readonly string id;

        public Employee(string name, int income, string id)
        {
            this.Name = name;
            this.Income = income;
            this.id = id;
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
            set
            {
                this.name = value;
            }
        }

        public int Income
        {
            get
            {
                return this.income;
            }
            set
            {
                this.income = value;
            }
        }
    }
}
