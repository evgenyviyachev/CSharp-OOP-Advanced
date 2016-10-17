using _071984.Attributes;
using _071984.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Models
{
    public class Company : ISubject
    {
        [Subject("name")]
        private string name;
        [Subject("turnover")]
        private int turnover;
        [Subject("revenue")]
        private int revenue;
        private readonly string id;

        public Company(string name, int turnover, int revenue, string id)
        {
            this.Name = name;
            this.Turnover = turnover;
            this.Revenue = revenue;
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

        public int Turnover
        {
            get
            {
                return this.turnover;
            }
            set
            {
                this.turnover = value;
            }
        }

        public int Revenue
        {
            get
            {
                return this.revenue;
            }
            set
            {
                this.revenue = value;
            }
        }
    }
}
