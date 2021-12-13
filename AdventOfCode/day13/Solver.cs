namespace AdventOfCode.day13; 

public static class Solver {

    private static (Grid, List<Instruction>) LoadData(string filename) {
        var instructions = new List<Instruction>();
        var marks = new List<(int, int)>();
        foreach (var line in File.ReadLines(filename)) {
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line.StartsWith("fold")) {
                var instruction = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2];
                var instructionSplit = instruction.Split('=', StringSplitOptions.RemoveEmptyEntries);
                instructions.Add(new Instruction(instructionSplit[0], int.Parse(instructionSplit[1])));
            } else {
                var coords = line.Split(",");
                marks.Add((int.Parse(coords[0]), int.Parse(coords[1])));
            }
        }

        var grid = new Grid(marks);
        return (grid, instructions);
    }
    
    public static int SolveStar1(string filename = "day13/input1.txt") {
        var (grid, instructions) = LoadData(filename);
        var newGrid = grid.Fold(instructions[0]);
        return newGrid.GetMarkCount();
    }

    public static string SolveStar2(string filename = "day13/input1.txt") {
        var (grid, instructions) = LoadData(filename);
        foreach (var fold in instructions) {
            grid = grid.Fold(fold);
        }

        return grid.Print();
    }
}