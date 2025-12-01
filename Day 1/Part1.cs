using System.IO;

class Day1Part1
{
    
    public static void Run()
    {
        var rotations = GetInput();
        
        Lock lockObject = new Lock(50);
        foreach (var rotation in rotations)
        {
            lockObject.Rotate(rotation);
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

class Lock
{
    private int _maxPosition = 99;
    private int _currentPosition = 0;
    private int _numberOfZeroes = 0;

    public Lock(int currentPosition)
    {
        _currentPosition = currentPosition;
    }

    public void Rotate(Rotations rotation)
    {
        var rotationDegrees = rotation.RotationDirection == Rotations.Direction.Left ? rotation.Degrees * -1 : rotation.Degrees;
        _currentPosition = ((_currentPosition + rotationDegrees) + _maxPosition + 1) % (_maxPosition + 1);

        if (_currentPosition == 0) _numberOfZeroes++;
    }
    
    public int GetPosition => _currentPosition; 
    public int GetNumberOfZeroes => _numberOfZeroes;
}

class Rotations
{

    public enum Direction
    {
        Left = 0,
        Right = 1
    }

    public Direction? RotationDirection = null;
    public int Degrees = 0;

    public Direction GetDirection(string directionInput)
    {
        directionInput = directionInput.ToLower();
        return directionInput == "l" ? Direction.Left : Direction.Right;
    }
}