namespace AdventOfCode.day8; 

public static class Solver {
    private static List<SignalLine> GetData(string filename) {
        var data = new List<SignalLine>();
        foreach (var line in File.ReadAllLines(filename)) {
            var signalOutputSplit = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
            var signalData = signalOutputSplit[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var output = signalOutputSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            data.Add(new SignalLine(
                    signalData.Select(s => new Digit(s)),
                    output.Select(s => new Digit(s))
            ));
        }

        return data;
    }
    
    public static int SolveStar1(string filename = "day8/input1.txt") {
        var signalLines = GetData(filename);
        return signalLines
            .SelectMany(sl => sl.Output)
            .Count(s => s.Segments.Length is 2 or 4 or 3 or 7);
    }

    public static int SolveStar2(string filename = "day8/input1.txt") {
        var signalLines = GetData(filename);
        return signalLines.Sum(sl => sl.Decode());
    }
}