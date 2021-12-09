namespace AdventOfCode.day9; 

public class Grid {
    
    public int Width { get; }
    public int Height { get; }
    private readonly int[,] _grid;
    
    public Grid(List<List<int>> lines) {
        Width = lines[0].Count;
        Height = lines.Count;
        _grid = new int[Width, Height];
        var y = 0;
        foreach (var line in lines) {
            var x = 0;
            foreach (var val in line) {
                _grid[x, y] = val;
                x++;
            }
            y++;
        }
    }

    private bool TestForLowPoint(int x, int y) {
        var value = _grid[x, y];
        if (y > 0 && _grid[x, y - 1] <= value) return false;
        if (y < Height - 1 && _grid[x, y + 1] <= value) return false;
        if (x > 0 && _grid[x - 1, y] <= value) return false;
        if (x < Width - 1 && _grid[x + 1, y] <= value) return false;
        return true;
    }

    public IEnumerable<(int, int, int)> FindLowPoints() {
        for (var x = 0; x < Width; x++) {
            for (var y = 0; y < Height; y++) {
                if (TestForLowPoint(x, y)) {
                    yield return (x, y, _grid[x, y]);
                }
            }
        }
    }

    public int ValueAt(int x, int y) => _grid[x, y];

    public IEnumerable<Basin> FindBasins() {
        return FindLowPoints().Select(lp => new Basin(this, lp.Item1, lp.Item2));
    }
}