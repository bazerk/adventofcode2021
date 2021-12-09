namespace AdventOfCode.day9; 

public class Basin {
    private readonly Grid _grid;
    private readonly HashSet<(int, int)> _members = new();

    public int Size => _members.Count;

    public Basin(Grid grid, int x, int y) {
        _grid = grid;
        _members.Add((x, y));
        Explore(x + 1, y);
        Explore(x - 1, y);
        Explore(x, y - 1);
        Explore(x, y + 1);
    }

    private void Explore(int x, int y) {
        if (x < 0 || y < 0 || x >= _grid.Width || y >= _grid.Height) return;
        if (_members.Contains((x, y))) return;
        if (_grid.ValueAt(x, y) == 9) return;
        _members.Add((x, y));
        Explore(x + 1, y);
        Explore(x - 1, y);
        Explore(x, y - 1);
        Explore(x, y + 1);
    }
}