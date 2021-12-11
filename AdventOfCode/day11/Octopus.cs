namespace AdventOfCode.day11; 

public class Octopus {
    private const int FlashOn = 10;

    public int X { get; }
    public int Y { get; }
    private int _energyLevel; 
    private bool _flashed;
    
    public Octopus(int x, int y, int energyLevel) {
        X = x;
        Y = y;
        _energyLevel = energyLevel;
    }

    public bool Tick() {
        _flashed = false;
        return IncreaseEnergy();
    }

    public bool IncreaseEnergy() {
        if (_flashed) return false;
        _energyLevel += 1;
        return _energyLevel == FlashOn;
    }
    
    public void Flash() {
        _flashed = true;
        _energyLevel = 0;
    }
}