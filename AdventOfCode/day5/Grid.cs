namespace AdventOfCode.day5; 

public class Grid {
    private readonly int _width;
    private readonly int _height;
    private readonly int[,] _grid;
    
    public Grid(int width, int height) {
        _width = width;
        _height = height;
        _grid = new int[width, height];
    }

    public void AddLine(Line line, bool skipDiagonals = false) {
        if (skipDiagonals && line.To.X != line.From.X && line.To.Y != line.From.Y) {
            return;
        }

        var travelX = 0;
        if (line.From.X < line.To.X) {
            travelX = 1;
        } else if (line.From.X > line.To.X) {
            travelX = -1;
        }
        
        var travelY = 0;
        if (line.From.Y < line.To.Y) {
            travelY = 1;
        } else if (line.From.Y > line.To.Y) {
            travelY = -1;
        }

        var x = line.From.X;
        var y = line.From.Y;
        _grid[x, y] += 1;
        do {
            x += travelX;
            y += travelY;
            _grid[x, y] += 1;
        } while (x != line.To.X || y != line.To.Y);
    }

    public IEnumerable<int> GetVentValues() {
        for (var x = 0; x < _width; x++) {
            for (var y = 0; y < _height; y++) {
                yield return _grid[x, y];
            }
        }
    }
}