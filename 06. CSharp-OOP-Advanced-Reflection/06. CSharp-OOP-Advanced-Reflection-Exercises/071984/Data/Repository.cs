using _071984.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Data
{
    public class Repository
    {
        private List<ISubject> employeesCompanies = new List<ISubject>();
        private List<IInstitution> institutions = new List<IInstitution>();

        public List<ISubject> EmployeesCompanies
        {
            get
            {
                return this.employeesCompanies;
            }
        }

        public List<IInstitution> Institutions
        {
            get
            {
                return this.institutions;
            }
        }

        public void AddEmplyeeOrCompany(ISubject subject)
        {
            this.employeesCompanies.Add(subject);
        }

        public void AddInstitution(IInstitution institution)
        {
            this.institutions.Add(institution);
        }
    }
}
