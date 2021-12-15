namespace AdventOfCode.day15; 

public class GridPath {
    private HashSet<(int, int)> _travelled;
    public (int, int) Position { get; private set; }
    public int Cost { get; private set; }

    public GridPath() {
        _travelled = new HashSet<(int, int)> {
            (0, 0)
        };
        Cost = 0;
        Position = (0, 0);
    }

    private GridPath(GridPath clone) {
        _travelled = new HashSet<(int, int)>(clone._travelled);
        Cost = clone.Cost;
        Position = clone.Position;
    }

    public GridPath Move(int x, int y, int cost) {
        var newPath = new GridPath(this);
        newPath._travelled.Add((x, y));
        newPath.Position = (x, y);
        newPath.Cost += cost;
        return newPath;
    }

    public bool CanMove(int x, int y) {
        return !_travelled.Contains((x, y));
    }

    public IEnumerable<(int, int)> SurroundingPositions() {
        var (x, y) = Position;
        yield return (x - 1, y);
        yield return (x, y - 1);
        yield return (x + 1, y);
        yield return (x, y + 1);
    }
}