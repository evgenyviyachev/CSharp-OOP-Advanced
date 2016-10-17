using _071984.Contracts;
using _071984.Data;
using _071984.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Core
{
    public class Engine : IRunable
    {
        private Repository repo;

        public Engine(Repository repo)
        {
            this.repo = repo;
        }

        public void Run(int m, int n, int p)
        {
            for (int i = 0; i < m; i++)
            {
                string[] data = Console.ReadLine().Split();
                if (data[0] == "Employee")
                {
                    Employee employee = new Employee(data[2], int.Parse(data[3]), data[1]);
                    this.repo.AddEmplyeeOrCompany(employee);
                }
                else
                {
                    Company company = new Company(data[2], int.Parse(data[3]), int.Parse(data[4]), data[1]);
                    this.repo.AddEmplyeeOrCompany(company);
                }
            }

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                List<string> fieldsToWatch = data.Skip(3).ToList();
                Institution institution = new Institution(data[2], data[1], fieldsToWatch);
                this.repo.AddInstitution(institution);
            }

            for (int i = 0; i < p; i++)
            {
                string[] data = Console.ReadLine().Split();
                string id = data[0];
                string fieldName = data[1];
                string newValue = data[2];

                var institutions = this.repo.Institutions.Where(ins => ins.FieldsToWatch.Contains(fieldName)).ToList();

                ISubject subject = this.repo.EmployeesCompanies.First(isub => isub.ID == id);
                FieldInfo field = subject.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

                if (field == null)
                {
                    continue;
                }

                string oldValue = field.GetValue(subject).ToString();
                string fieldType = field.FieldType.Name;

                if (fieldType.StartsWith("I"))
                {
                    fieldType = "int";
                }

                string typeOfEntity = subject.GetType().Name;

                int num;

                if (int.TryParse(newValue, out num))
                {
                    field.SetValue(subject, num);
                }
                else
                {
                    field.SetValue(subject, newValue);
                }                

                foreach (var inst in institutions)
                {
                    inst.RegisterChange(typeOfEntity, id, fieldName, fieldType, oldValue, newValue);
                }
            }

            foreach (var inst in this.repo.Institutions)
            {
                inst.PrintInstitution();
            }
        }
    }
}
