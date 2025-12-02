namespace AdventOfCode2025.Day_1;

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