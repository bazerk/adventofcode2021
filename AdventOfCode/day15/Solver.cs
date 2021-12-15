namespace AdventOfCode.day15; 

public static class Solver {
    private static Grid GetData(string filename, bool expandGrid = false) {
        var lines = File.ReadLines(filename)
            .Select(l => l.Select(ch => int.Parse(ch.ToString())).ToList())
            .ToList();
        return new Grid(lines, expandGrid);
    }
    
    public static int SolveStar1(string filename = "day15/input1.txt") {
        var grid = GetData(filename);
        var gridPath = grid.FindShortest();
        return gridPath.Cost;
    }
    
    public static int SolveStar2(string filename = "day15/input1.txt") { 
        var grid = GetData(filename, true);
        var gridPath = grid.FindShortest();
        return gridPath.Cost;   
    }

    public static string ExpandedGridAsString(string filename = "day15/input1.txt") {
        var grid = GetData(filename, true);
        return grid.PrintGrid();
    }
}
