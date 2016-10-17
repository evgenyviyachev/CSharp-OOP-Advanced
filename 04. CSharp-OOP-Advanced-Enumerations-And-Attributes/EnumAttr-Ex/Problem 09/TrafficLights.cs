using System;
using System.Collections.Generic;
using System.Linq;

public enum TrafficLight
{
    Red,
    Green,
    Yellow
}

public class TrafficLights
{
    public static void Main()
    {
        List<TrafficLight> list = Console.ReadLine()
            .Split()
            .Select(x => (TrafficLight)Enum.Parse(typeof(TrafficLight), x, true))
            .ToList();

        int numberOfChanges = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfChanges; i++)
        {
            List<TrafficLight> lights = new List<TrafficLight>();

            foreach (TrafficLight light in list)
            {
                int num = ((int)light + 1) % 3;
                lights.Add((TrafficLight)num);
            }

            list = lights;
            Console.WriteLine(string.Join(" ", list));
        }
    }
}