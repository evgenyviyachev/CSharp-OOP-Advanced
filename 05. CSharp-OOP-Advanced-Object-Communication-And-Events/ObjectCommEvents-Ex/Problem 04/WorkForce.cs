using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Employee
{
    public Employee(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }
    public int HoursPerWeek { get; protected set; }
}

public class StandartEmployee : Employee
{
    private readonly int WorkingHoursPerWeek = 40;

    public StandartEmployee(string name)
        : base(name)
    {
        this.HoursPerWeek = WorkingHoursPerWeek;
    }
}

public class PartTimeEmployee : Employee
{
    private readonly int WorkingHoursPerWeek = 20;

    public PartTimeEmployee(string name)
        : base(name)
    {
        this.HoursPerWeek = WorkingHoursPerWeek;
    }
}

public delegate void MyDelegate(Job job);

public class Job
{
    public Job(string name, int hoursOfWorkRequired, Employee employee)
    {
        this.Name = name;
        this.HoursOfWorkRequired = hoursOfWorkRequired;
        this.Employee = employee;
    }

    public string Name { get; private set; }
    public int HoursOfWorkRequired { get; private set; }
    public Employee Employee { get; private set; }
    public static event MyDelegate JobFinished;
    public bool IsToRemove { get; set; }

    public void Update()
    {
        this.HoursOfWorkRequired -= this.Employee.HoursPerWeek;
        if (this.HoursOfWorkRequired <= 0)
        {
            if (JobFinished != null)
            {
                JobFinished(this);
            }            
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
    }
}

public static class Jobs
{
    public static List<Job> jobs = new List<Job>();

    public static void Subscribe()
    {
        Job.JobFinished += Job_JobFinished;
    }

    private static void Job_JobFinished(Job job)
    {
        Console.WriteLine($"Job {job.Name} done!");
        job.IsToRemove = true;
    }

    public static void AddJob(Job job)
    {
        jobs.Add(job);
    }

    public static void RemoveFinishedJobs()
    {
        jobs.RemoveAll(j => j.IsToRemove);
    }
}

public class WorkForce
{
    public static void Main()
    {
        Jobs.Subscribe();
        List<Employee> employees = new List<Employee>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] data = input.Split();

            switch (data[0])
            {
                case "Job":
                    string employeeName = data[3];
                    Employee employee = employees.First(e => e.Name == employeeName);
                    Job job = new Job(data[1], int.Parse(data[2]), employee);
                    Jobs.AddJob(job);
                    break;
                case "StandartEmployee":
                    Employee employeeNew = new StandartEmployee(data[1]);
                    employees.Add(employeeNew);
                    break;
                case "PartTimeEmployee":
                    Employee employeeNew2 = new PartTimeEmployee(data[1]);
                    employees.Add(employeeNew2);
                    break;
                case "Pass":
                    foreach (var jobToUpdate in Jobs.jobs)
                    {
                        jobToUpdate.Update();
                    }
                    Jobs.RemoveFinishedJobs();
                    break;
                case "Status":
                    foreach (var jobToPrint in Jobs.jobs)
                    {
                        Console.WriteLine(jobToPrint);
                    }
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}