namespace AdventOfCode.day11; 

public class OctoGrid {
    private int _width;
    private int _height;
    private readonly Octopus[,] _octopi;

    public int OctoCount => _octopi.Length;
    
    public OctoGrid(List<List<int>> lines) {
        _width = lines[0].Count;
        _height = lines.Count;
        _octopi = new Octopus[_width, _height];
        var y = 0;
        foreach (var line in lines) {
            var x = 0;
            foreach (var val in line) {
                _octopi[x, y] = new Octopus(x, y, val);
                x++;
            }
            y++;
        }
    }

    private IEnumerable<Octopus> GetNeighbours(int flashX, int flashY) {
        for (var x = flashX - 1; x <= flashX + 1; x++) {
            for (var y = flashY - 1; y <= flashY + 1; y++) {
                if (x < 0 || y < 0) continue;
                if (x == flashX && y == flashY) continue;
                if (x >= _width || y >= _height) continue;
                yield return _octopi[x, y];
            }
        }
    }

    public int Step() {
        int flashes = 0;
        var toFlash = new Queue<Octopus>();
        foreach (var octopus in _octopi) {
            if (octopus.Tick()) {
                toFlash.Enqueue(octopus);
            }
        }

        while (toFlash.Count > 0) {
            var octopus = toFlash.Dequeue();
            octopus.Flash();
            flashes++;

            foreach (var neighbour in GetNeighbours(octopus.X, octopus.Y)) {
                if (neighbour.IncreaseEnergy()) {
                    toFlash.Enqueue(neighbour);
                }
            }
        }

        return flashes;
    }

    public int StepFor(int stepCount) {
        int flashes = 0;
        while (stepCount > 0) {
            stepCount--;
            flashes += Step();
        }

        return flashes;
    }
}