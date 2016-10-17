using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ISoldier
{
    string Id { get; }
    string FirstName { get; }
    string LastName { get; }
}

public abstract class Soldier : ISoldier
{
    public Soldier(string id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}

public interface IPrivate
{
    double Salary { get; }
}

public class Private : Soldier, IPrivate
{
    public Private(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public double Salary { get; private set; }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}\n";
    }
}

public interface ILeutenantGeneral
{
    List<Private> Privates { get; }
}

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private List<Private> privates;

    public LeutenantGeneral(string id, string firstName, string lastName, double salary, List<Private> privates)
        : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public List<Private> Privates
    {
        get
        {
            return this.privates;
        }
        set
        {
            this.privates = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
            .Append(Environment.NewLine).Append("Privates:").Append(Environment.NewLine);
        
        foreach (var privateSoldier in this.Privates)
        {
            sb.Append("  ").Append(privateSoldier.ToString());
        }

        return sb.ToString();
    }
}

public interface ISpecialisedSoldier
{
    string Corps { get; }
}

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string corps;

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps
    {
        get
        {
            return this.corps;
        }
        private set
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException();
            }

            this.corps = value;
        }
    }
}

public interface IEngineer
{
    Dictionary<string, int> Repairs { get; }
}

public class Engineer : SpecialisedSoldier, IEngineer
{
    private Dictionary<string, int> repairs;

    public Engineer(string id, string firstName, string lastName, double salary, string corps, Dictionary<string, int> repairs)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public Dictionary<string, int> Repairs
    {
        get
        {
            return this.repairs;
        }
        private set
        {
            this.repairs = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
            .Append(Environment.NewLine).Append($"Corps: {this.Corps}")
            .Append(Environment.NewLine).Append("Repairs:").Append(Environment.NewLine);

        foreach (var pair in this.Repairs)
        {
            sb.Append("  ").Append($"Part Name: {pair.Key} Hours Worked: {pair.Value}")
                .Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}

public interface ICommando
{
    Dictionary<string, string> Missions { get; }
    void CompleteMission(string missionName);
}

public class Commando : SpecialisedSoldier, ICommando
{
    private Dictionary<string, string> missions;

    public Commando(string id, string firstName, string lastName, double salary, string corps, Dictionary<string, string> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public Dictionary<string, string> Missions
    {
        get
        {
            return this.missions;
        }
        private set
        {
            this.missions = value;
        }
    }

    public void CompleteMission(string missionName)
    {
        if (this.Missions.ContainsKey(missionName))
        {
            this.Missions[missionName] = "Finished";
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
            .Append(Environment.NewLine).Append($"Corps: {this.Corps}")
            .Append(Environment.NewLine).Append("Missions:").Append(Environment.NewLine);

        foreach (var pair in this.Missions)
        {
            sb.Append("  ").Append($"Code Name: {pair.Key} State: {pair.Value}")
                .Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}

public interface ISpy
{
    string CodeNumber { get; }
}

public class Spy : Soldier, ISpy
{
    public Spy(string id, string firstName, string lastName, string codeNumber)
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public string CodeNumber { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id}")
            .Append(Environment.NewLine).Append($"Code Number: {this.CodeNumber.TrimStart('0')}")
            .Append(Environment.NewLine);

        return sb.ToString();
    }
}

public class MilitaryElite
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<Soldier> soldiers = new List<Soldier>();

        while (input != "End")
        {
            string[] data = input.Split();

            switch (data[0])
            {
                case "Private":
                    Private privateSoldier = new Private(data[1], data[2], data[3], double.Parse(data[4]));
                    soldiers.Add(privateSoldier);
                    break;
                case "LeutenantGeneral":
                    List<Private> privates = new List<Private>();
                    for (int i = 5; i < data.Length; i++)
                    {
                        string privateId = data[i];
                        Private currentPrivate = (Private)soldiers.First(s => s.Id == privateId);
                        privates.Add(currentPrivate);
                    }
                    LeutenantGeneral ltGeneral = new LeutenantGeneral(data[1], data[2], data[3], double.Parse(data[4]), privates);
                    soldiers.Add(ltGeneral);
                    break;
                case "Engineer":
                    Dictionary<string, int> repairs = new Dictionary<string, int>();
                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string repairPart = data[i];
                        int repairHours = int.Parse(data[i + 1]);
                        repairs.Add(repairPart, repairHours);
                    }
                    try
                    {
                        Engineer engineer = new Engineer(data[1], data[2], data[3], double.Parse(data[4]), data[5], repairs);
                        soldiers.Add(engineer);
                    }
                    catch (ArgumentException)
                    {
                    }
                    break;
                case "Commando":
                    Dictionary<string, string> missions = new Dictionary<string, string>();

                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string missionName = data[i];
                        string missionState = data[i + 1];

                        if (missionState == "inProgress" || missionState == "Finished")
                        {
                            missions.Add(missionName, missionState);
                        }
                    }
                    try
                    {
                        Commando commando = new Commando(data[1], data[2], data[3], double.Parse(data[4]), data[5], missions);
                        soldiers.Add(commando);
                    }
                    catch (ArgumentException)
                    {
                    }
                    break;
                case "Spy":
                    Spy spy = new Spy(data[1], data[2], data[3], data[4]);
                    soldiers.Add(spy);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }

        foreach (var soldier in soldiers)
        {
            Console.Write(soldier);
        }
    }
}