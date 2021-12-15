using System.Text;

namespace AdventOfCode.day15; 

public class Grid {
    private const int ExpandBy = 5;
    
    public int Width { get; }
    public int Height { get; }
    private readonly int[,] _grid;
    private readonly (int, int) _destination;
    
    public Grid(List<List<int>> lines, bool expandGrid = false) {
        var inputWidth = lines[0].Count;
        var inputHeight = lines.Count;
        
        Width = inputWidth;
        Height = inputHeight;
        if (expandGrid) {
            Width *= ExpandBy;
            Height *= ExpandBy;
        }
        
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

        if (expandGrid) {
            // For each horizontal section
            for (int sectionX = 0; sectionX < ExpandBy; sectionX++) {
                // If not the initial grid - copy from the left
                if (sectionX != 0) {
                    for (var x = sectionX * inputWidth; x < inputWidth * (sectionX + 1); x++) {
                        for (y = 0; y < inputHeight; y++) {
                            var value = _grid[x - inputWidth, y] + 1;
                            if (value > 9) {
                                value = 1;
                            }

                            _grid[x, y] = value;
                        }
                    }
                }
                // Expand down
                for (int sectionY = 1; sectionY < ExpandBy; sectionY++) {
                    for (var x = sectionX * inputWidth; x < inputWidth * (sectionX + 1); x++) {
                        for (y = sectionY * inputHeight; y < inputHeight * (sectionY + 1); y++) {
                            var value = _grid[x, y - inputHeight] + 1;
                            if (value > 9) {
                                value = 1;
                            }
                            _grid[x, y] = value;
                        }
                    }
                }
            }
        }

        _destination = (Width - 1, Height - 1);
    }

    public GridPath FindShortest() {
        var currentShortestPath = new GridPath();
        var candidatePaths = new List<GridPath>();
        var minPositionCosts = new Dictionary<(int, int), int>();
        
        while (currentShortestPath.Position != _destination) {
            // For the current shortest path - add all possible neighbours, then find the new shortest path and
            // repeat
            foreach (var pos in currentShortestPath.SurroundingPositions()) {
                var (x, y) = pos;
                if (x < 0 || x >= Width) continue;
                if (y < 0 || y >= Height) continue;
                if (!currentShortestPath.CanMove(x, y)) continue;
                var newPath = currentShortestPath.Move(x, y, _grid[x, y]);
                var bestPositionCost = minPositionCosts.GetValueOrDefault(pos, int.MaxValue);
                if (newPath.Cost >= bestPositionCost) continue;
                minPositionCosts[pos] = newPath.Cost;
                candidatePaths.Add(newPath);
            }

            candidatePaths = candidatePaths.Where(p => minPositionCosts[p.Position] == p.Cost).ToList();
            var shortest = candidatePaths.OrderBy(x => x.Cost).First();
            currentShortestPath = shortest;
            candidatePaths.Remove(shortest);
        }

        return currentShortestPath;
    }

    public string PrintGrid() {
        var sb = new StringBuilder((Width + 1) * Height);
        for (var y = 0; y < Height; y++) {
            for (var x = 0; x < Width; x++) {
                sb.Append(_grid[x, y]);
            }

            if (y != Height - 1) {
                sb.Append(Environment.NewLine);
            }
        }

        return sb.ToString();
    }
}