namespace AdventOfCode2025.Day_1;

class Locks
{
    private int _maxPosition = 99;
    private int _currentPosition = 0;
    private int _numberOfZeroes = 0;

    public Locks(int currentPosition)
    {
        _currentPosition = currentPosition;
    }

    public void RotateAndCountExactZeroes(Rotations rotation)
    {
        var rotationDegrees = rotation.RotationDirection == Rotations.Direction.Left ? rotation.Degrees * -1 : rotation.Degrees;
        _currentPosition = ((_currentPosition + rotationDegrees) + _maxPosition + 1) % (_maxPosition + 1);

        if (_currentPosition == 0) _numberOfZeroes++;
    }
    
    public void RotateAndCountAllZeroes(Rotations rotation)
    {
        int fullRotations = Math.Abs(rotation.Degrees) / (_maxPosition + 1);
        rotation.Degrees = rotation.Degrees - (fullRotations * (_maxPosition + 1));
        var rotationDegrees = rotation.RotationDirection == Rotations.Direction.Left ? rotation.Degrees * -1 : rotation.Degrees;
        var newPosition = ((_currentPosition + rotationDegrees) + _maxPosition + 1) % (_maxPosition + 1);

        if (_currentPosition != 0 && newPosition != 0)
        {
            if (newPosition > _currentPosition && rotation.RotationDirection == Rotations.Direction.Left) _numberOfZeroes++;
            else if (newPosition < _currentPosition && rotation.RotationDirection == Rotations.Direction.Right) _numberOfZeroes++;
        }
        
        _currentPosition = newPosition;
        _numberOfZeroes += fullRotations + Convert.ToInt32(_currentPosition == 0);
    }
    
    public int GetPosition => _currentPosition; 
    public int GetNumberOfZeroes => _numberOfZeroes;
}