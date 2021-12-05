namespace AdventOfCode.day5; 

public static class Solver {

    public static IEnumerable<Line> GetLines(string filename) {
        Point GetPoint(string pointString) {
            var split = pointString.Split(',');
            return new Point {
               X = int.Parse(split[0]),
               Y = int.Parse(split[1])
            };
        }
        
        foreach (var dataLine in File.ReadAllLines(filename)) {
            var points = dataLine.Split(" -> ");
            yield return new Line {
                From = GetPoint(points[0]),
                To = GetPoint(points[1]),
            };
        }
    }

    public static int Solve(string filename, bool skipDiagonals) {
        var lines = GetLines(filename).ToList();
        var maxX = 0;
        var maxY = 0;
        foreach (var line in lines) {
            var lineMaxX = Math.Max(line.From.X, line.To.X);
            if (lineMaxX > maxX) {
                maxX = lineMaxX;
            }

            var lineMaxY = Math.Max(line.From.Y, line.To.Y);
            if (lineMaxY > maxY) {
                maxY = lineMaxY;
            }
        }

        var grid = new Grid(maxX + 1, maxY + 1);
        foreach (var line in lines) {
            grid.AddLine(line, skipDiagonals);
        }

        return grid.GetVentValues().Count(value => value > 1);
    }
        
    
    public static int SolveStar1(string filename = "day5/input1.txt") {
        return Solve(filename, true);
    }
    
    public static int SolveStar2(string filename = "day5/input1.txt") {
        return Solve(filename, false);
    }
}