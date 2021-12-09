namespace AdventOfCode.day9; 

public static class Solver {

    private static Grid LoadGrid(string filename) {
        var lines = File.ReadAllLines(filename).ToList();
        return new Grid(lines.Select(l => l.Select(ch => int.Parse(ch.ToString())).ToList()).ToList());
    }
    
    public static int SolveStar1(string filename = "day9/input1.txt") {
        var grid = LoadGrid(filename);
        return grid.FindLowPoints().Select(x => x.Item3 + 1).Sum();
    }

    public static int SolveStar2(string filename = "day9/input1.txt") {
        var grid = LoadGrid(filename);
        var basinSizes = grid.FindBasins().Select(b => b.Size).OrderByDescending(s => s).ToList();
        return basinSizes[0] * basinSizes[1] * basinSizes[2];
    }
}