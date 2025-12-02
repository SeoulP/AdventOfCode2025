using System.IO;
using AdventOfCode2025.Day_1;

class Day1Part2
{
    
    public static void Run()
    {
        Console.WriteLine("Starting Day 1-2");

        var rotations = GetInput();
        
        Locks lockObject = new Locks(50);
        foreach (var rotation in rotations)
        {
            lockObject.RotateAndCountAllZeroes(rotation);
        }

        Console.WriteLine(lockObject.GetNumberOfZeroes);
    }
    
    private static List<Rotations> GetInput()
    {
        List<Rotations> rotations = new List<Rotations>();
        var input = File.ReadAllLines($@"Inputs\input_day1.txt").ToList();

        foreach (String line in input)
        {
            Rotations rotation = new Rotations();
            rotation.RotationDirection = rotation.GetDirection(line.Substring(0, 1));
            rotation.Degrees = int.Parse(line.Substring(1));
            
            rotations.Add(rotation);
        }
        
        return rotations;
    }   
}