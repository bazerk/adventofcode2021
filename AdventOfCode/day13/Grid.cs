using System.Text;

namespace AdventOfCode.day13; 

public class Grid {
    private readonly int _width;
    private readonly int _height;
    private readonly bool[,] _squares;
    
    public Grid(List<(int, int)> markedSquares, int? width = null, int? height = null) {
        if (width == null || height == null) {
            // First we discover the width and height
            var maxX = 0;
            var maxY = 0;
            foreach (var (x, y) in markedSquares) {
                if (x > maxX) maxX = x;
                if (y > maxY) maxY = y;
            }

            width = maxX + 1;
            height = maxY + 1;
        }

        _width = width.Value;
        _height = height.Value;

        _squares = new bool[_width, _height];
        foreach (var (x, y) in markedSquares) {
            _squares[x, y] = true;
        }
    }

    public int GetMarkCount() {
        return IterateMarkedSquares().Count();
    }

    private IEnumerable<(int, int)> IterateMarkedSquares() {
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                if (_squares[x, y]) yield return (x, y);
            }
        }
    }

    public Grid Fold(Instruction instruction) {
        var newMarkedSquares = new List<(int, int)>();
        var height = _height;
        var width = _width;
        if (instruction.Axis == Instruction.FoldAxis.X) {
            width = instruction.FoldAt;
            foreach (var (x, y) in IterateMarkedSquares()) {
                if (x < instruction.FoldAt) {
                    newMarkedSquares.Add((x, y));
                } else if (x > instruction.FoldAt) {
                    var distanceFromFold = x - instruction.FoldAt;
                    newMarkedSquares.Add((instruction.FoldAt - distanceFromFold, y));
                }
            }            
            
        } else {
            height = instruction.FoldAt;
            foreach (var (x, y) in IterateMarkedSquares()) {
                if (y < instruction.FoldAt) {
                    newMarkedSquares.Add((x, y));
                } else if (y > instruction.FoldAt) {
                    var distanceFromFold = y - instruction.FoldAt;
                    newMarkedSquares.Add((x, instruction.FoldAt - distanceFromFold));
                }
            }
        }

        return new Grid(newMarkedSquares, width, height);
    }

    public string Print() {
        var output = new StringBuilder();
        for (int y = 0; y < _height; y++) {
            for (int x = 0; x < _width; x++) {
                if (_squares[x, y]) output.Append("#");
                else output.Append(".");
            }

            output.Append(Environment.NewLine);
        }

        return output.ToString();
    }
}