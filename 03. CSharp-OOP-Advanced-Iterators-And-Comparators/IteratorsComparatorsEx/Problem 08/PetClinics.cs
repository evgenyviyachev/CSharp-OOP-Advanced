using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pet
{
    private string name;
    private int age;
    private string kind;

    public Pet(string name, int age, string kind)
    {
        this.name = name;
        this.age = age;
        this.kind = kind;
    }

    public string Name => this.name;
    public int Age => this.age;
    public string Kind => this.kind;
}

public class Clinic
{
    private string name;
    private int numberOfRooms;
    private Room[] rooms;

    public Clinic(string name, int numberOfRooms)
    {
        this.name = name;
        this.numberOfRooms = numberOfRooms;
        this.rooms = new Room[this.numberOfRooms];

        for (int i = 0; i < this.rooms.Length; i++)
        {
            this.rooms[i] = new Room();
        }
    }

    public string Name => this.name;

    public bool AddPet(Pet pet)
    {
        bool added = false;

        int middle = (this.rooms.Length - 1) / 2;
        Room middleRoom = this.rooms[middle];

        if (middleRoom.AddPet(pet))
        {
            added = true;

            if (this.rooms.Length == 1)
            {
                return added;
            }
        }
        else
        {
            if (this.rooms.Length == 1)
            {
                return added;
            }

            for (int i = middle - 1; i >= 0; i--)
            {
                int difference = middle - i;
                if (this.rooms[middle - difference].AddPet(pet))
                {
                    added = true;
                    break;
                }
                if (this.rooms[middle + difference].AddPet(pet))
                {
                    added = true;
                    break;
                }
            }
        }

        return added;
    }

    public bool RemovePet()
    {
        bool removed = false;

        int middle = (this.rooms.Length - 1) / 2;

        for (int i = middle; i < this.rooms.Length; i++)
        {
            if (this.rooms[i].RemovePet())
            {
                removed = true;
                break;
            }
        }

        if (!removed)
        {
            for (int i = 0; i < middle; i++)
            {
                if (this.rooms[i].RemovePet())
                {
                    removed = true;
                    break;
                }
            }
        }

        return removed;
    }

    public bool HasEmptyRooms()
    {
        return this.rooms.Any(r => r.Pet == null);
    }

    public string PrintRoom(int numberOfRoom)
    {
        return rooms[numberOfRoom - 1].ToString() + "\n";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var room in this.rooms)
        {
            sb.Append(room).Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}

public class Room
{
    private Pet pet;

    public Room()
    {
        this.pet = null;
    }

    public Pet Pet => this.pet;

    public bool AddPet(Pet pet)
    {
        if (this.Pet == null)
        {
            this.pet = pet;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemovePet()
    {
        if (this.Pet != null)
        {
            this.pet = null;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        if (this.Pet == null)
        {
            return "Room empty";
        }

        return $"{this.Pet.Name} {this.Pet.Age} {this.Pet.Kind}";
    }
}

public class PetClinics
{
    public static void Main()
    {
        int numberOfCommands = int.Parse(Console.ReadLine());
        List<Pet> pets = new List<Pet>();
        List<Clinic> clinics = new List<Clinic>();

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] command = Console.ReadLine().Split();

            switch (command[0])
            {
                case "Create":
                    if (command[1] == "Pet")
                    {
                        Pet pet = new Pet(command[2], int.Parse(command[3]), command[4]);
                        pets.Add(pet);
                    }
                    else if (command[1] == "Clinic")
                    {
                        int numberOfRooms = int.Parse(command[3]);

                        if (numberOfRooms % 2 == 0)
                        {
                            Console.WriteLine("Invalid Operation!");
                        }
                        else
                        {
                            Clinic clinic = new Clinic(command[2], numberOfRooms);
                            clinics.Add(clinic);
                        }
                    }
                    break;
                case "Add":
                    if (!pets.Any(p => p.Name == command[1])
                        || !clinics.Any(c => c.Name == command[2]))
                    {
                        Console.WriteLine("Invalid Operation!");
                    }
                    else
                    {
                        Pet pet = pets.First(p => p.Name == command[1]);
                        Clinic clinic = clinics.First(c => c.Name == command[2]);
                        Console.WriteLine(clinic.AddPet(pet));
                    }
                    break;
                case "Release":
                    if (!clinics.Any(c => c.Name == command[1]))
                    {
                        Console.WriteLine("Invalid Operation!");
                    }
                    else
                    {
                        Clinic clinic = clinics.First(c => c.Name == command[1]);
                        Console.WriteLine(clinic.RemovePet());
                    }
                    break;
                case "HasEmptyRooms":
                    if (!clinics.Any(c => c.Name == command[1]))
                    {
                        Console.WriteLine("Invalid Operation!");
                    }
                    else
                    {
                        Clinic clinic = clinics.First(c => c.Name == command[1]);
                        Console.WriteLine(clinic.HasEmptyRooms());
                    }
                    break;
                case "Print":
                    if (!clinics.Any(c => c.Name == command[1]))
                    {
                        Console.WriteLine("Invalid Operation!");
                    }
                    else
                    {
                        if (command.Length == 2)
                        {
                            Clinic clinic = clinics.First(c => c.Name == command[1]);
                            Console.Write(clinic.ToString());
                        }
                        else if (command.Length == 3)
                        {
                            Clinic clinic = clinics.First(c => c.Name == command[1]);
                            Console.Write(clinic.PrintRoom(int.Parse(command[2])));
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}