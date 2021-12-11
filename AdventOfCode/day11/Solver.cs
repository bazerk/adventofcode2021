namespace AdventOfCode.day11; 

public static class Solver {
 
    private static OctoGrid LoadGrid(string filename) {
        var lines = File.ReadAllLines(filename).ToList();
        return new OctoGrid(lines.Select(l => l.Select(ch => int.Parse(ch.ToString())).ToList()).ToList());
    }

    public static int SolveStar1(string filename = "day11/input1.txt", int stepCount = 100) {
        var grid = LoadGrid(filename);
        return grid.StepFor(stepCount);
    }

    public static int SolveStar2(string filename = "day11/input1.txt") {
        var grid = LoadGrid(filename);
        int step = 0;
        var flashes = 0;
        
        while (flashes != grid.OctoCount) {
            flashes = grid.Step();
            step += 1;
        }

        return step;
    }
}